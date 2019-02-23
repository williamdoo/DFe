using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class ObsCont
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "xCampo")]
        public string XCampo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "xTexto")]
        public string XTexto { get; set; }
    }
}
