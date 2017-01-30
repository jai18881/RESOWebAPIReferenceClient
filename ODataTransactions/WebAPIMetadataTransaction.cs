using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESOClientLibrary;

namespace ODataTransactions
{
    public class WebAPIMetadataTransaction : WebAPITransaction
    {

        public WebAPIMetadataTransaction(RESOClientSettings clientsettings)
            : base(clientsettings)
        {
        }


        public bool ExecuteEvent(RESOClient app)
        {
            try
            {
                responsedata = app.GetODataMetadata(clientsettings.GetSetting(settings.webapi_uri).TrimEnd('/') + "/$metadata");
                app.LogData("Response Data");
                app.LogData("METADATA", responsedata);
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
