using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ReferenceLibrary;
using System.Collections;
using System.Net.Cache;

namespace RESOClientLibrary
{
    public delegate void OutputLog(string logentry);
    public class OAuthToken
    {
        public string access_token;
        public string expires_in;
        public string token_type;
        public string refresh_token;
        public string id_token;
        public string state;

    }

    public class RESOClient
    {
        RESOLogging debuglog = null; 
        public RESOClientSettings clientsettings { get; set; }
        private OutputLog outputlog;
        public StringBuilder ClientLog = new StringBuilder();
        public OAuthToken oauth_token { get; set; }
        private CredentialCache credentials = new CredentialCache();
        public string logrequestheader { get; set; }
        private string url { get; set; }
        public Response responseobject { get; set; }
        public Hashtable responseheaders = null;

        public RESOClient(RESOClientSettings settings, OutputLog log)
        {
            this.clientsettings = settings;
            ClientLog = new StringBuilder();
            outputlog = log;
        }
        private void SetCredentials(Uri url, string authType, NetworkCredential creds)
        {
       
                this.credentials.Remove(url, authType);
                this.credentials.Add(url, authType, creds);
        }
        private void PrepareCredentials(string url)
        {


            Uri uri = new System.Uri(url);
            SetCredentials(uri, "Digest", new NetworkCredential(clientsettings.GetSetting(settings.oauth_clientidentification), clientsettings.GetSetting(settings.oauth_clientsecret)));
            SetCredentials(uri, "Basic", new NetworkCredential(clientsettings.GetSetting(settings.oauth_clientidentification), clientsettings.GetSetting(settings.oauth_clientsecret)));
            LogData("Set URL:", uri.AbsoluteUri);

        }
        public void LogData(string label, string data)
        {
            if (ClientLog == null)
            {
                ClientLog = new StringBuilder();
            }
            string output = string.Empty;
            if (!string.IsNullOrEmpty(label))
            {
                output += label;
                ClientLog.Append(label);
                output += ":";
                ClientLog.Append(":");
            }
            output += data;
            ClientLog.Append(data);
            output += "\r\n";
            ClientLog.Append("\r\n");
            if (outputlog != null)
            {
                outputlog(output);
            }

        }
        public void LogData(string label)
        {
            if (ClientLog == null)
            {
                ClientLog = new StringBuilder();
            }
            ClientLog.Append("-------------------- ");
            ClientLog.Append(label);
            ClientLog.Append(" --------------------");
            ClientLog.Append("\r\n");
        }
        public string PostData(string posturl, string postData, bool preauth)
        {
            string responsetext = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(posturl);
            request.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; });
            X509Certificate Cert = X509Certificate.CreateFromCertFile(clientsettings.GetSetting(settings.certificatepath));
            request.ClientCertificates.Add(Cert);

            try
            {

                url = posturl;
                PrepareCredentials(posturl);


                // Set the Method property of the request to POST.
                request.Method = "POST";
                if (!preauth)
                {
                    request.Credentials = credentials;
                }
                else
                {
                    string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(clientsettings.GetSetting(settings.oauth_clientidentification)
                                                                + ":" + clientsettings.GetSetting(settings.oauth_clientsecret)));
                    request.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
                }
                //request.PreAuthenticate = true;
                request.KeepAlive = false;
                request.AllowAutoRedirect = false;
                HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                request.CachePolicy = noCachePolicy;
                // Create POST data and convert it to a byte array.
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;

                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.

                string headerstext = string.Empty;
                request.Expect = string.Empty;
                request.Connection = string.Empty;
                //request.Headers.Remove("Expect");
                foreach (string key in request.Headers.AllKeys)
                {
                    LogData(key, request.Headers[key].ToString());
                    headerstext += key + "=" + request.Headers[key].ToString() + "\r\n";
                }
                HttpWebResponse response = null;
                try
                {
                    response = (HttpWebResponse)request.GetResponse() as HttpWebResponse;
                }
                catch (WebException we)
                {
                    HttpWebResponse resp = we.Response as HttpWebResponse;
                    if (resp == null)
                        throw;
                    if (!preauth)
                    {
                        if ((resp.StatusCode == HttpStatusCode.BadRequest) || (resp.StatusCode == HttpStatusCode.Unauthorized))
                        {
                            string returnsecond = PostData(posturl, postData, true);
                            return returnsecond;
                        }
                    }
                    else
                    {
                        throw;
                    }
                }


                SaveResponseData(response);
                // Display the status.
                string responsedata = response.StatusDescription;
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                responsetext = reader.ReadToEnd();
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return responsetext;
        }

        private void SaveResponseData(HttpWebResponse response)
        {
            //responseobject = response;

            responseheaders = new Hashtable();
            LogData("Response Headers");
            foreach (string key in response.Headers.AllKeys)
            {
                string keylow = key.ToLower();
                string value = response.Headers[key] as string;
                if (responseheaders[keylow] == null)
                {
                    responseheaders[keylow] = value;
                    LogData(key, value);
                }
                else
                {
                    LogData("ERROR Duplicate Response Header", key + ":" + value);
                }
            }
        }
        public string GetData(string uri)
        {
            try
            {

                Uri test = new Uri(uri);

                // Create a request using a URL that can receive a post. 
                HttpWebRequest request = (HttpWebRequest)WebRequest.CreateHttp(test);
                request.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; });
                X509Certificate Cert = X509Certificate.CreateFromCertFile(clientsettings.GetSetting(settings.certificatepath));
                request.ClientCertificates.Add(Cert);
                //request.Accept = Constants.ContentTypeJson;
                // Set the Method property of the request to POST.
                request.Method = "GET";
                request.KeepAlive = true;
                //request.Headers.Add("Accept-Encoding", "gzip,deflate");
                PrepareCredentials(uri);
                request.Credentials = credentials;

                if (oauth_token != null)
                {
                    request.Headers.Add("Authorization", oauth_token.token_type + " " + oauth_token.access_token);
                }
                request.UserAgent = clientsettings.GetSetting(settings.useragent);

                request.ProtocolVersion = HttpVersion.Version11;

                logrequestheader = string.Empty;
                foreach (string key in request.Headers.AllKeys)
                {
                    string keylow = key.ToLower();
                    string value = request.Headers[key] as string;
                    LogData(key, value);
                    logrequestheader += key + "=" + value + "\r\n";

                }

                //responseobject = WebHelper.Post
                responseobject = WebHelper.Get(request, 999999);

                return responseobject.ResponsePayload;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string GetODataMetadata(string uri)
        {
            try
            {

                Uri test = new Uri(uri);

                // Create a request using a URL that can receive a post. 
                HttpWebRequest request = (HttpWebRequest)WebRequest.CreateHttp(test);
                request.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; });
                X509Certificate Cert = X509Certificate.CreateFromCertFile(clientsettings.GetSetting(settings.certificatepath));
                request.ClientCertificates.Add(Cert);
                //request.Accept = Constants.V4AcceptHeaderJsonFullMetadata;
                // Set the Method property of the request to POST.
                request.Method = "GET";
                request.KeepAlive = true;
                //request.Headers.Add("Accept-Encoding", "gzip,deflate");
                PrepareCredentials(uri);
                request.Credentials = credentials;
                if (oauth_token != null)
                {
                    request.Headers.Add("Authorization", oauth_token.token_type + " " + oauth_token.access_token);
                }
                request.UserAgent = clientsettings.GetSetting(settings.useragent);

                request.ProtocolVersion = HttpVersion.Version11;

                logrequestheader = string.Empty;
                foreach (string key in request.Headers.AllKeys)
                {
                    string keylow = key.ToLower();
                    string value = request.Headers[key] as string;
                    LogData(key, value);
                    logrequestheader += key + "=" + value + "\r\n";

                }

                //string acceptHeader = Constants.V4AcceptHeaderJsonFullMetadata;
                //Response response = WebHelper.Get(test, acceptHeader, RuleEngineSetting.Instance().DefaultMaximumPayloadSize, request.Headers as HttpWebRequest);

                responseobject = WebHelper.Get(request, 999999);

                return responseobject.ResponsePayload;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
