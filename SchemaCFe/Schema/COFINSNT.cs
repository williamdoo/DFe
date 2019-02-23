using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class COFINSNT
    {
        /// <summary>
        /// Código de Situação Tributária do COFINS
        /// </summary>
        [XmlElement(ElementName = "CST")]
        public string CST { get; set; }
    }
}