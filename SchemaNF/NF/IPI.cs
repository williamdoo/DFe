using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class IPI
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "clEnq")]
        public string ClEnq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "CNPJProd")]
        public string CNPJProd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "cSelo")]
        public string CSelo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "qSelo")]
        public string QSelo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "cEnq")]
        public string CEnq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "IPITrib")]
        public IPITrib IPITrib { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "IPINT")]
        public IPINT IPINT { get; set; }
    }
}
