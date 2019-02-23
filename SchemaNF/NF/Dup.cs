using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Dup
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "nDup")]
        public string NDup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "dVenc")]
        public string DVenc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vDup")]
        public string VDup { get; set; }
    }
}
