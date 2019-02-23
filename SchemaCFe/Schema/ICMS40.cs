using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class ICMS40
    {
        /// <summary>
        /// Origem da mercadoria
        /// </summary>
        [XmlElement(ElementName = "Orig")]
        public string Orig { get; set; }

        /// <summary>
        /// Tributação do ICMS = 40, 41, 60
        /// </summary>
        [XmlElement(ElementName = "CST")]
        public string CST { get; set; }
    }
}