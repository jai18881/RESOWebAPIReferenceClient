using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RESOClientLibrary
{
    public class Request
    {
        public string url;
        public string verb;
        public string outputfile;
        public string validationid;
        public string method;
        public string payload;
    }
    public class LoadTestScript
    {
        string xmldata = string.Empty;
        public Hashtable parameters = new Hashtable();
        public List<Request> requests = new List<Request>();

        public bool LoadData(string filename)
        {
            int dir = filename.LastIndexOf('\\');
            string directory = filename.Substring(0, dir);
            
            string dirname = filename.Substring(dir + 1, filename.Length - (dir + 1));
            int ex = dirname.LastIndexOf('.');
            dirname = "results_" + dirname.Substring(0,ex);
            parameters["config_defaultresultsdirectory"] = directory + "\\" + dirname;
        
            using (XmlReader reader = XmlReader.Create(new StreamReader(filename)))
            {
                string parentelement = string.Empty;
                string childelement = string.Empty;
                string text = string.Empty;
                // Parse the file and display each of the nodes.
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if(reader.Name == "ServerParameters" || reader.Name == "ClientSettings" || reader.Name == "Parameters" || reader.Name == "Requests")
                            {
                                if(parentelement != reader.Name)
                                {
                                    parentelement = string.Empty;
                                }
                            }
                            if (string.IsNullOrEmpty(parentelement))
                            {
                                if ((reader.Name != "OutputScript") && (reader.Name != "Parameters") && (reader.Name != "Requests"))
                                {
                                    parentelement = reader.Name;
                                    if (reader.HasAttributes)
                                    {
                                        if (parentelement == "Request")
                                        {
                                            AddRequest(reader);
                                            childelement = string.Empty;
                                            text = string.Empty;
                                        }
                                        else
                                        {
                                            childelement = reader.GetAttribute("Name");
                                            text = reader.GetAttribute("Value");
                                            SetParameter(ref parameters, parentelement, childelement, text);
                                            childelement = string.Empty;
                                            text = string.Empty;

                                        }
                                        SetParameter(ref parameters, parentelement, childelement, text);
                                        

                                        childelement = string.Empty;
                                        text = string.Empty;

                                    }
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(childelement))
                                {
                                    childelement = reader.Name;
                                    if (reader.HasAttributes)
                                    {
                                        if (childelement == "Request")
                                        {
                                            AddRequest(reader);

                                            childelement = string.Empty;
                                            text = string.Empty;

                                        }
                                        else
                                        {
                                            childelement = reader.GetAttribute("Name");
                                            text = reader.GetAttribute("Value");
                                            SetParameter(ref parameters, parentelement, childelement, text);
                                      
                                            childelement = string.Empty;
                                            text = string.Empty;
                                        }
                                    }
                                }
                            }

                            break;
                        case XmlNodeType.Text:
                            if (string.IsNullOrEmpty(text))
                            {
                                text = reader.Value;
                            }
                            break;
                        case XmlNodeType.XmlDeclaration:
                        case XmlNodeType.ProcessingInstruction:
                            //writer.WriteProcessingInstruction(reader.Name, reader.Value);
                            break;
                        case XmlNodeType.Comment:
                            //writer.WriteComment(reader.Value);
                            break;
                        case XmlNodeType.EndElement:
                            if (!string.IsNullOrEmpty(parentelement))
                            {
                                if (reader.HasAttributes)
                                {
                                    string name = reader.GetAttribute("Name");
                                    string value = reader.GetAttribute("Value");
                                }
                                SetParameter(ref parameters, parentelement, childelement, text);
                                //parentelement = string.Empty;
                                childelement = string.Empty;
                                text = string.Empty;
                            }
                            break;
                    }
                }
            }
            int count = requests.Count;
            return true;
        }

        private void SetParameter(ref Hashtable parameters, string parentelement, string childelement, string text)
        {
            if (!string.IsNullOrEmpty(childelement))
            {
                parameters[parentelement + "_" + childelement] = text;
            }
        }

        private void AddRequest(XmlReader reader)
        {
            string url = reader.GetAttribute("Url");
            ReplaceTokens(ref url);
            string method = reader.GetAttribute("Method");
            ReplaceTokens(ref method);
            string payload = reader.GetAttribute("Payload");
            ReplaceTokens(ref payload);

            string outputfile = reader.GetAttribute("OutputFile");
            ReplaceTokens(ref outputfile);
            string validator = reader.GetAttribute("Validator");
            ReplaceTokens(ref validator);
            Request req = new Request();
            if (!string.IsNullOrEmpty(method))
            {
                req.method = method;
            }
            else
            {
                req.method = "GET";
            }
            if (!string.IsNullOrEmpty(payload))
            {
                req.payload = payload;
            }
            else
            {
                req.payload = string.Empty;
            }
            if (!string.IsNullOrEmpty(url))
            {
                req.url = url;
            }
            if (!string.IsNullOrEmpty(outputfile))
            {
                req.outputfile = reader.GetAttribute("OutputFile");
            }
            if (!string.IsNullOrEmpty(validator))
            {
                req.outputfile = reader.GetAttribute("Validator");
            }
            requests.Add(req);
        }

        private void ReplaceTokens(ref string origstring)
        {
            if (string.IsNullOrEmpty(origstring))
            {
                return;
            }
            foreach (DictionaryEntry item in parameters)
            {
                string key = item.Key as string;
                string value = item.Value as string;
                if (origstring.IndexOf("*" + key + "*") >= 0)
                {
                    origstring = origstring.Replace("*" + key + "*", value);
                }
            }
        }
    }
}
