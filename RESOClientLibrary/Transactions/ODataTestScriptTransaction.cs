using ReferenceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESOClientLibrary.Transactions
{
    public class EventRequest
    {
        public string url { get; set; }
        public string outputfile { get; set; }
        public string validationid { get; set; }
        public string method { get; set; }
        public string payload { get; set; }
    }

    public class ODataTestScriptTransaction : ODataTransaction
    {

        public Response responseobject { get; set; }

        public ODataTestScriptTransaction(RESOClientSettings clientsettings)
            : base(clientsettings)
        { 

        }

        public bool ExecuteEvent(RESOClient app, EventRequest eventitem, string outputdirectory, ref RESOLogging debuglog)
        {
            try
            {
                if (debuglog != null) debuglog.LogLabel("EventRequest" + eventitem.url);
                responsedata = app.GetData(eventitem.url);
                responseobject = app.responseobject;
                app.LogData(eventitem.outputfile);
                app.LogData(eventitem.outputfile, responsedata);
                StringBuilder sbresponse = new StringBuilder();
                sbresponse.Append("_____________________________REQUEST_____________________________");
                sbresponse.Append("\r\n");
                sbresponse.Append(app.logrequestheader);
                sbresponse.Append("\r\n");
                sbresponse.Append(eventitem.url);
                sbresponse.Append("\r\n");
                sbresponse.Append("_____________________________RESPONSE_____________________________");
                sbresponse.Append("\r\n");
                sbresponse.Append(responseobject.StatusCode);
                sbresponse.Append("\r\n");
                sbresponse.Append(responseobject.ResponseHeaders);
                sbresponse.Append("\r\n");
                sbresponse.Append(responseobject.ResponsePayload);
                sbresponse.Append("\r\n");

                using (System.IO.StreamWriter file =
                                          new System.IO.StreamWriter(outputdirectory + "\\" + eventitem.outputfile, false))
                {

                    file.WriteLine(sbresponse.ToString());
                }

                if (debuglog != null) debuglog.LogData(sbresponse.ToString());
            }
            catch (Exception ex)
            {
                if(debuglog != null)
                {
                    debuglog.LogException("OdataTestScriptTransaction:ExecuteEvent", ex.Message);
                }
                app.LogData("ERROR", ex.Message);
                return false;
            }
            return true;
        }
    }
}
