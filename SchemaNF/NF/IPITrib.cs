using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class IPITrib
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "CST")]
        public string CST { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vBC")]
        public string VBC { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "pIPI")]
        public string PIPI { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "qUnid")]
        public string QUnid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vUnid")]
        public string VUnid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vIPI")]
        public string VIPI { get; set; }
    }
}
