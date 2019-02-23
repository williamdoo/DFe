using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Exporta
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "UFEmbarq")]
        public string UFEmbarq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "xLocEmbarq")]
        public string XLocEmbarq { get; set; }
    }
}
