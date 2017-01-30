using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace RESOClientLibrary
{
    public enum settings
    {
        standard,
        version,
        rets_username,
        rets_password,
        useragent,
        rets_useragentpasswordhash,
        rets_initialurl,
        rets_domainurl,
        rets_port,
        oauth_redirecturi,
        oauth_authorizationuri,
        oauth_tokenuri,
        oauth_clientidentification,
        oauth_clientscope,
        oauth_clientsecret,
        oauth_granttype,
        openid_code,
        webapi_uri,
        certificatepath,
        rulecontroloutput,
        rulecontrolinput,
        rulescontrolfile,
        testscript,
        outputdirectory,
        log_directory,
        results_directory
    }

    public class RESOClientSettings
    {
        public Hashtable settingvalues = new Hashtable();
        public NameValueCollection accessurls = new NameValueCollection();

        public string GetSetting(settings setting)
        {
            if (settingvalues[setting] != null)
            {
                return settingvalues[setting] as string;
            }
            return string.Empty;
        }

        public void SetSetting(settings setting, string value)
        {
            if (setting == settings.testscript)
            {
                settingvalues[setting] = value;
            }
            else
            {
                settingvalues[setting] = value;
            }
        }
        internal string GetVersion()
        {
            if (GetSetting(settings.version).ToUpper().IndexOf(GetSetting(settings.standard)) < 0)
            {
                return GetSetting(settings.version) + "/" + GetSetting(settings.standard);
            }
            return GetSetting(settings.version);
        }
    }
}
