using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Transporta
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "CNPJ")]
        public string CNPJ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "CPF")]
        public string CPF { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "xNome")]
        public string XNome { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "IE")]
        public string IE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "xEnder")]
        public string XEnder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "xMun")]
        public string XMun { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "UF")]
        public string UF { get; set; }
    }
}
