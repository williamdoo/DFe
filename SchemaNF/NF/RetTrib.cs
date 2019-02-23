using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class RetTrib
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vRetPIS")]
        public string VRetPIS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vRetCOFINS")]
        public string VRetCOFINS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vRetCSLL")]
        public string VRetCSLL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vBCIRRF")]
        public string VBCIRRF { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vIRRF")]
        public string VIRRF { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vBCRetPrev")]
        public string VBCRetPrev { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vRetPrev")]
        public string VRetPrev { get; set; }
    }
}
