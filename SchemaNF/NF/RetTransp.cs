using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class RetTransp
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vServ")]
        public string VServ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vBCRet")]
        public string VBCRet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "pICMSRet")]
        public string PICMSRet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vICMSRet")]
        public string VICMSRet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "CFOP")]
        public string CFOP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "cMunFG")]
        public string CMunFG { get; set; }
    }
}
