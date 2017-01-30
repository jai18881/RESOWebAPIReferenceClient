using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESOClientLibrary.Transactions
{
    public class ODataTransaction
    {
        public RESOClientSettings clientsettings { get; set; }
        public RESOClient clientapp { get; set; }
        private string url { get; set; }
        public string responsedata { get; set; }
        private Hashtable responsemap = new Hashtable();

        public ODataTransaction(RESOClientSettings settings)
        {
            this.clientsettings = settings;
            
        }
        virtual protected void setResponseData(string body)
        {

        }
        virtual protected void setClientApp(RESOClient app)
        {
            clientapp = app;
        }

        protected string getURL()
        {
            return url;
        }
        protected void setURL(string url_value)
        {
            url = url_value;
        }

        public void setResponseVariable(String key, String value)
        {
            responsemap[key] = value;
        }
        public String getResponseVariable(String key)
        {
            return (String)responsemap[key];
        }
        
    }
}
