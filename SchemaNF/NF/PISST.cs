using System.Xml.Serialization;

namespace SchemaNF.NF
{
    /// <summary>
    /// 
    /// </summary>
    /// <summary>
	/// 
	/// </summary>
	public class PISST
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vBC")]
        public string VBC { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "pPIS")]
        public string PPIS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "qBCProd")]
        public string QBCProd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vAliqProd")]
        public string VAliqProd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vPIS")]
        public string VPIS { get; set; }
    }
}
