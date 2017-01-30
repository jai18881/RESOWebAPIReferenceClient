using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceLibrary
{
    #region Namespaces
    using System.Xml;
    #endregion

    /// <summary>
    /// Class of namespace manager for Atompub XML parsing
    /// </summary>
    public sealed class ODataNamespaceManager : XmlNamespaceManager
    {
        /// <summary>
        /// The unique instance of singleton
        /// </summary>
        private static ODataNamespaceManager instance = new ODataNamespaceManager();

        /// <summary>
        /// Creates instance of AtompubNamespaceManager
        /// </summary>
        private ODataNamespaceManager()
            : base(new NameTable())
        {
            this.AddNamespace("app", "http://www.w3.org/2007/app");
            this.AddNamespace("atom", "http://www.w3.org/2005/Atom");
            this.AddNamespace("m", "http://docs.oasis-open.org/odata/ns/edm/dataservices/metadata");
            this.AddNamespace("metadata", "http://docs.oasis-open.org/odata/ns/metadata");
            this.AddNamespace("edmx", "http://docs.oasis-open.org/odata/ns/edmx");
            this.AddNamespace("edm", "http://docs.oasis-open.org/odata/ns/edm");

        }

        /// <summary>
        /// The single access point for the singleton class
        /// </summary>
        public static ODataNamespaceManager Instance
        {
            get
            {
                return ODataNamespaceManager.instance;
            }
        }
    }
}
