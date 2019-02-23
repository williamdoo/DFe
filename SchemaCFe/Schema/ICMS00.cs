using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class ICMS00
    {
        /// <summary>
        /// Origem da mercadoria 
        /// </summary>
        [XmlElement(ElementName = "Orig")]
        public string Orig { get; set; }

        /// <summary>
        /// Tributação do ICMS = 00, 20, 90
        /// </summary>
        [XmlElement(ElementName = "CST")]
        public string CST { get; set; }

        /// <summary>
        /// Alíquota efetiva do imposto
        /// </summary>
        [XmlElement(ElementName = "pICMS")]
        public string PICMS { get; set; }

        /// <summary>
        /// Valor do ICMS
        /// </summary>
        [XmlElement(ElementName = "vICMS")]
        public string VICMS { get; set; }
    }
}