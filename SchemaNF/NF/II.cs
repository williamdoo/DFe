using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class II
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vBC")]
        public string VBC { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vDespAdu")]
        public string VDespAdu { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vII")]
        public string VII { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vIOF")]
        public string VIOF { get; set; }
    }
}
