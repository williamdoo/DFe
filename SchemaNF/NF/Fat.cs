using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Fat
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "nFat")]
        public string NFat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vOrig")]
        public string VOrig { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vDesc")]
        public string VDesc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vLiq")]
        public string VLiq { get; set; }
    }
}
