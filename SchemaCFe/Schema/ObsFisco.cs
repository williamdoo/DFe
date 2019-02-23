using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class ObsFisco
    {
        /// <summary>
        /// Identificação do campo
        /// </summary>
        [XmlElement(ElementName = "xCampo")]
        public string XCampo { get; set; }

        /// <summary>
        /// Conteúdo do campo
        /// </summary>
        [XmlElement(ElementName = "xTexto")]
        public string XTexto { get; set; }
    }
}