using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class Dest
    {
        /// <summary>
        /// CNPJ do destinatário
        /// </summary>
        [XmlElement(ElementName = "CNPJ")]
        public string CNPJ { get; set; }

        /// <summary>
        /// CPF do destinatário
        /// </summary>
        [XmlElement(ElementName = "CPF")]
        public string CPF { get; set; }

        /// <summary>
        /// Razão Social ou Nome do destinatário
        /// </summary>
        [XmlElement(ElementName = "xNome")]
        public string XNome { get; set; }
    }
}