using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class DescAcrEntr
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vDescSubtot")]
        public string VDescSubtot { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vAcresSubtot")]
        public string VAcresSubtot { get; set; }
    }
}
