using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Lacres
    {
        /// <summary>
        /// Número dos Lacres
        /// </summary>
        [XmlElement(elementName: "nLacre")]
        public string NLacre { get; set; }
    }
}
