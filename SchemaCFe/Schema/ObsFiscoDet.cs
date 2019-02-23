using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class ObsFiscoDet
    {
        /// <summary>
        /// Identificação do campo
        /// </summary>
        [XmlElement(ElementName = "xCampoDet")]
        public string XCampoDet { get; set; }

        /// <summary>
        /// Conteúdo do campo
        /// </summary>
        [XmlElement(ElementName = "xTextoDet")]
        public string XTextoDet { get; set; }
    }
} 