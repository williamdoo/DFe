using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class AutXML
    {
        /// <summary>
        /// Informar CNPJ. Preencher os zeros não significativos.
        /// </summary>
        [XmlElement(elementName: "CNPJ")]
        public string CNPJ { get; set; }
        /// <summary>
        /// Informar CPF. Preencher os zeros não significativos.
        /// </summary>
        [XmlElement(elementName: "CPF")]
        public string CPF { get; set; }
    }
}
