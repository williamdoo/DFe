using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Reboque
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "placa")]
        public string Placa { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "UF")]
        public string UF { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "RNTC")]
        public string RNTC { get; set; }
    }
}
