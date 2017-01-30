using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ReferenceLibrary
{
    public delegate void RESOLog(string logid, string logentry);
    public class RESOLogging
    {
        StringBuilder log = new StringBuilder();
        private RESOLog outputlog;
        string outputfile = string.Empty;
        string headerid = string.Empty;
        bool append = false;
        public RESOLogging(string logid, string outfile, bool appenddata, RESOLog logdelegate = null)
        {
            outputlog = logdelegate;
            outputfile = outfile;
            headerid = logid;
            LogLabelandData("HEADER ID", headerid);
            LogData(DateTime.Now.ToString());
        }
     
        public bool OutputLogFile()
        {
            return OutputLogFile(outputfile, !append);
        }

        public bool OutputLogFile(string filename, bool newfile)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, newfile))
                {

                    file.WriteLine(log.ToString());
                }
            }
            catch (Exception ex)
            {
                log.Append(ex.Message);
                return false;
            }
            return true;
        }
        public void LogLabelandData(string label, string data)
        {
            if (log == null)
            {
                log = new StringBuilder();
            }
            string output = string.Empty;
            if (!string.IsNullOrEmpty(label))
            {
                output += label;
                log.Append(label);
                output += ":";
                log.Append(":");
            }
            output += data;
            log.Append(data);
            output += "\r\n";
            log.Append("\r\n");
            if (outputlog != null)
            {
                outputlog(headerid,output);
            }

        }

        public void LogLabel(string label)
        {
            string output = string.Empty;
            if (log == null)
            {
                log = new StringBuilder();
            }
            log.Append("-------------------- ");
            output = "-------------------- ";
            log.Append(label);
            output += label;
            log.Append(" --------------------");
            output += " --------------------\r\n";
            log.Append("\r\n");
            if (outputlog != null)
            {
                outputlog(headerid, output);
            }
        }
        public void LogData(string data)
        {
            if (log == null)
            {
                log = new StringBuilder();
            }

            log.Append(data);
        
            log.Append("\r\n");
            if (outputlog != null)
            {
                outputlog(headerid, data+"\r\n");
            }
        }


        public void LogException(string ClassFunction, string Message)
        {
            LogLabelandData("EXCEPTION", ClassFunction + ":" + Message);
        }
    }
}
