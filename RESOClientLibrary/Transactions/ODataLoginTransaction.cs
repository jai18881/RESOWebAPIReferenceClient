using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RESOClientLibrary.Transactions
{
    public class ODataLoginTransaction : ODataTransaction
    {
        internal OAuthToken oauth_token { get; set; }
        public string[] LoginData { get; set; }
        public NameValueCollection loginaccessurls { get; set; }


        public ODataLoginTransaction(RESOClientSettings clientsettings) : base(clientsettings) { }




        public string getCapabilityUrl(string p)
        {
            GetAccessURLs();
            return loginaccessurls[p] as string;

        }


        internal void ExecuteEvent()
        {

        }

        public bool ExecuteEvent(RESOClient app, bool preauth)
        {
            try
            {

                setClientApp(app);
                setURL(app.clientsettings.GetSetting(settings.oauth_tokenuri));
                app.LogData("Begin Login Event");
                if (string.IsNullOrEmpty(app.clientsettings.GetSetting(settings.openid_code)))
                {
                    app.LogData("No Code Available");
                    return false;
                }
                responsedata = app.PostData(getURL(), BuildTokenRequest(app.clientsettings), preauth);

                if (!string.IsNullOrEmpty(responsedata))
                {
                    setResponseData(responsedata);
                    app.LogData("Login Response");
                    app.LogData("", responsedata);
                    SaveLoginParameters(responsedata);
                    app.oauth_token = oauth_token;
                }
            }
            catch (Exception ex)
            {

                app.LogData("LOGIN TRANSACTION ERROR", ex.Message);
                return false;
                //throw ex;
            }
            return true;

        }

     

        private string BuildTokenRequest(RESOClientSettings clientsettings)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("grant_type=");
            sb.Append(clientsettings.GetSetting(settings.oauth_granttype));
            sb.Append("&");
            sb.Append("code=");
            sb.Append(clientsettings.GetSetting(settings.openid_code));
            sb.Append("&");
            sb.Append("redirect_uri=");
            sb.Append(clientsettings.GetSetting(settings.oauth_redirecturi));
            sb.Append("&");
            sb.Append("client_id=");
            sb.Append(clientsettings.GetSetting(settings.oauth_clientidentification));
             return sb.ToString();
        }



        private void SaveLoginParameters(string loginresponse)
        {

            oauth_token = JsonConvert.DeserializeObject<OAuthToken>(loginresponse);
            if (string.Compare(oauth_token.token_type, "bearer", true) == 0)
            {
                oauth_token.token_type = "Bearer";
            }
        }

        public NameValueCollection GetAccessURLs()
        {
            if (loginaccessurls == null)
            {
                loginaccessurls = new NameValueCollection();
                if (LoginData == null)
                {
                    return loginaccessurls;
                }
                foreach (string data in LoginData)
                {
                    if (data.IndexOf("=") >= 0)
                    {
                        string infotest = "INFO=";
                        int infopos = data.ToUpper().IndexOf(infotest);

                        if (infopos < 0)
                        {
                            string[] datasplit = data.Split('=');
                            loginaccessurls.Set(datasplit[0] as string, datasplit[1] as string);
                            setResponseVariable(datasplit[0], datasplit[1] as string);
                        }
                        else
                        {
                            string value = data.Substring(infopos + infotest.Length, data.Length - infopos - infotest.Length);
                            string[] datasplit = value.Split(';');


                            setResponseVariable(datasplit[0], value);
                        }
                    }
                }

            }
            return loginaccessurls;
        }


    }
}
