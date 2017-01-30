using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESOClientLibrary.Transactions
{
    public class ODataServiceTransaction : ODataTransaction
    {
        public ODataServiceTransaction(RESOClientSettings clientsettings)
            : base(clientsettings)
        {

        }
        public bool ExecuteEvent(RESOClient app)
        {
            try
            {
                string host = app.clientsettings.GetSetting(settings.webapi_uri).TrimEnd('/');
                host = host + "/";

                responsedata = app.GetData(host);

                app.LogData("Service Data");
                app.LogData("SERVICE DATA", responsedata);
            }
            catch (Exception ex)
            {
                app.LogData("ERROR", ex.Message);
                return false;
            }
            return true;
        }
    }
}
