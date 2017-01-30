using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESOClientLibrary.Templates
{
    public class RESOBaseTemplate
    {
        public string templatepath;
        string templatedata;
        bool dataloaded = false;
        public RESOBaseTemplate(string path)
        {
            templatepath = path;
        }
        virtual public void ReadFile()
        {
            ReadFile(templatepath.TrimEnd('\\') + "\\templates\\template.xml");
        }
        virtual public void ReadFile(string fn)
        {
            try
            {
                dataloaded = false;
                templatedata = File.ReadAllText(fn);
                dataloaded = true;

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
        public bool IsLoaded()
        {
            return dataloaded;
        }

        public virtual void FinalizeData()
        {
            //throw new NotImplementedException();
        }

        public virtual string GetTemplate()
        {
            return templatedata;
        }
    }
}
