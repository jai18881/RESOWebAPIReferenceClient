using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RESOClientLibrary;

namespace ODataTransactions
{
    public class WebAPITransaction
    {
        public string responsedata;
        public RESOClientSettings clientsettings;

        public WebAPITransaction(RESOClientSettings clientsettings)
        {
            // TODO: Complete member initialization
            this.clientsettings = clientsettings;
        }
    }
}
