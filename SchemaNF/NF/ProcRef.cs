using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class ProcRef
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "nProc")]
        public string NProc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "indProc")]
        public string IndProc { get; set; }
    }
}
