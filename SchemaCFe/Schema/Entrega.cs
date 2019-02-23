using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class Entrega
    {
        /// <summary>
        /// Logradouro
        /// </summary>
        [XmlElement(ElementName = "xLgr")]
        public string XLgrd { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        [XmlElement(ElementName = "nro")]
        public string Nro { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        [XmlElement(ElementName = "xCpl")]
        public string XCpl { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        [XmlElement(ElementName = "xBairro")]
        public string XBairro { get; set; }

        /// <summary>
        /// Nome do município
        /// </summary>
        [XmlElement(ElementName = "xMun")]
        public string XMun { get; set; }

        /// <summary>
        /// Sigla da UF
        /// </summary>
        [XmlElement(ElementName = "UF")]
        public string UF { get; set; }
    }
}