using RESOClientLibrary.Templates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RESOReference
{
    class ReferencePropertiesFile
    {
        Hashtable propertydata = new Hashtable();
        Hashtable newfieldnames = new Hashtable();
        Hashtable deprecated = new Hashtable();
        string filename = string.Empty;
        public string executablepath = string.Empty;
        public ReferencePropertiesFile()
        {
            newfieldnames["ServerVersion"] = "Version";
            newfieldnames["textScriptFile"] = "ScriptFile";
            newfieldnames["textOAuthAuthorizationURI"] = "AuthorizationURI";
            newfieldnames["textOAuthTokenURI"] = "TokenURI";
            newfieldnames["textWebAPIURI"] = "WebAPIURI";
            newfieldnames["textOAuthClientIdentification"] = "ClientIdentification";
            newfieldnames["textOAuthRedirectURI"] = "RedirectURI";
            newfieldnames["textOAuthClientSecret"] = "ClientSecret";
            newfieldnames["textOAuthClientScope"] = "ClientScope";
            newfieldnames["textOAuthUserName"] = "UserName";
            newfieldnames["textOAuthPassword"] = "Password";
            newfieldnames["transactionlogdirectory"] = "TransactionLogDirectory";
            newfieldnames["resultsdirectory"] = "ResultsDirectory";
            newfieldnames["textOAuthHost"] = "Host";
            newfieldnames["useragent"] = "UserAgent";
            newfieldnames["retsVersion"] = "RETSVersion";
            newfieldnames["textOAuthURI"] = "URI";
            newfieldnames["textWebAPIResource"] = "WebAPIResource";
            newfieldnames["textOAuthPort"] = "Port";

            deprecated["retsVersion"] = "retsVersion";
            deprecated["uaPassword"] = "uaPassword";
            deprecated["username"] = "username";
            deprecated["loginurl"] = "loginurl";
            deprecated["password"] = "password";
            deprecated["retsVersion"] = "RETSVersion";
            deprecated["textWebAPIHost"] = "textWebAPIHost";
        }
        virtual public void ReadStringArray(string filename, string[] data)
        {
            propertydata.Clear();
            int columncount = 0;
            string[] columndata = null;
            string line = string.Empty;
            try
            {
                for (int n = 0; n < data.Length; n++)
                {
                    line = data[n];
                    columndata = line.Split('=');
                    if (columncount == 0)
                    {
                        columncount = columndata.Length;
                    }
                    else if (columndata.Length != columncount)
                    {
                        continue;
                    }
                    AddData(filename, columndata, n);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FinalizeData();
            }
        }
        virtual public void ReadXMLStringArray(string filename, string[] data)
        {
            propertydata.Clear();
            string line = string.Empty;
            List<string> lines = new List<string>();
            bool start = false;
            for (int n = 1; n < data.Length; n++)
            {
                line = data[n];
                line = line.Trim();
                string columnname = GetDataBetween(line, "<", ">");
                if(columnname == "ClientSettings")
                {
                    start = true;
                    continue;
                }
                if(line.Trim() == "</ClientSettings>")
                {
                    start = false;
                    break;
                }
                if (start)
                {
                    string value = GetDataBetween(line, "<" + columnname + ">", "</" + columnname + ">").Trim();
                    lines.Add(columnname + "=" + value);
                }
            }
            ReadStringArray(filename,lines.ToArray());
        }
        public string GetDataBetween(string data, string start, string end)
        {
            int nStart = data.IndexOf(start);
            if (nStart < 0)
            {
                return "";
            }
            try
            {
                data = data.Substring(nStart + start.Length, data.Length - (start.Length + nStart));
            }
            catch (Exception)
            {
                
            }
            int nEnd = data.IndexOf(end);
            try
            {
                data = data.Substring(0, nEnd);
            }
            catch (Exception)
            {
                return string.Empty;
            }
            return data;
        }

        virtual public void ReadFile(string fn)
        {
            try
            {
                string[] data = File.ReadAllLines(fn, Encoding.Default);
                if(data.Length > 1)
                {
                    if(data[0].IndexOf("xml version") >= 0)
                    {
                        ReadXMLStringArray(fn, data);
                    }
                    else
                    {
                        ReadStringArray(fn, data);
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FinalizeData();
            }

        }

        virtual protected void FinalizeData()
        {

        }

        virtual protected void AddData(string filename, string[] columns, int row)
        {
            string newfieldname = newfieldnames[columns[0]] as string;

            if (string.IsNullOrEmpty(newfieldname))
            {
                if (propertydata[columns[0]] == null)
                {
                    propertydata[columns[0]] = columns[1];
                }
            }
            else if (propertydata[newfieldname] == null)
            {
                propertydata[newfieldname] = columns[1];
            }

        }
        virtual public string getProperty(string propertyname)
        {
            string newfieldname = newfieldnames[propertyname] as string;
            if (string.IsNullOrEmpty(newfieldname))
            {
                if (propertydata[propertyname] != null)
                {
                    return propertydata[propertyname] as string;
                }
            }
            else if (propertydata[newfieldname] != null)
            {
                return propertydata[newfieldname] as string;
            }
             

            return string.Empty;
        }

        virtual public void setProperty(string propertyname, string value)
        {
            string newfieldname = newfieldnames[propertyname] as string;
            if(string.IsNullOrEmpty(newfieldname))
            {
                propertydata[propertyname] = value;
            }
            else
            {
                propertydata[newfieldname] = value;
            }
        }

        virtual public string getTestFile()
        {
            return filename;
        }

        virtual public bool saveFile(string fn)
        {
            if (string.IsNullOrEmpty(executablepath))
            {
                return false;
            }
            string output = string.Empty;
            ClientSettingsTemplate template = new ClientSettingsTemplate(executablepath);
            template.ReadFile();
            if (template.IsLoaded())
            {
                output = template.GetTemplate();
                foreach (DictionaryEntry items in propertydata)
                {
                    if (deprecated[items.Key] != null)
                    {
                        continue;
                    }
                    output = output.Replace("*" + items.Key as string + "*", EscapeXML(items.Value as string));
                }
            }
            else
            {

                bool xml = true;
                StringBuilder sb = new StringBuilder();
                if (xml)
                {
                    sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                    sb.Append("\r\n");
                    sb.Append("<ClientSettings>");
                    sb.Append("\r\n");
                }
                foreach (DictionaryEntry items in propertydata)
                {
                    if (deprecated[items.Key] != null)
                    {
                        continue;
                    }

                    if (xml)
                    {
                        if (items.Key as string == "ClientSettings")
                        {
                            continue;
                        }
                        sb.Append("<");
                        sb.Append(items.Key as string);
                        sb.Append(">");
                        sb.Append(items.Value as string);
                        sb.Append("</");
                        sb.Append(items.Key as string);
                        sb.Append(">");

                        sb.Append("\r\n");

                    }
                    else
                    {
                        sb.Append(items.Key as string);
                        sb.Append("=");
                        sb.Append(EscapeXML(items.Value as string));
                        sb.Append("\r\n");
                    }

                }
                sb.Append("</ClientSettings>");
                sb.Append("\r\n");
                output = sb.ToString();
            }
            System.IO.File.WriteAllText(fn, output);
            return true;
        }
        private string EscapeXML(string data)
        {
            return data.Replace("&", "&amp;").Replace("\"", "\\\"").Replace("'", "&apos;").Replace("<", "&lt;").Replace(">", "&gt;");
        }
        public bool IsLoaded()
        {
            if (propertydata.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
