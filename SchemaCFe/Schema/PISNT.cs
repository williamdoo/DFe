using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class PISNT
    {
        /// <summary>
        /// Código de Situação Tributária do PIS
        /// </summary>
        [XmlElement(ElementName = "CST")]
        public string CST { get; set; }
    }
}