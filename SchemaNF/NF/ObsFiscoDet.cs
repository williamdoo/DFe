using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class ObsFiscoDet
    {
        /// <summary>
        /// Cod. CEST
        /// </summary>
        [XmlAttribute(attributeName: "xCampoDet")]
        public string XCampoDet { get; set; }

        /// <summary>
        /// Utilizar o CEST, conforme definido no Convênio ICMS nº 92/2015.
        /// </summary>
        [XmlElement(elementName: "xTextoDet")]
        public string XTextoDet { get; set; }
    }
}
