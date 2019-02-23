using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class ISSQN
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vBC")]
        public string VBC { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vAliq")]
        public string VAliq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vISSQN")]
        public string VISSQN { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "cMunFG")]
        public string CMunFG { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "cListServ")]
        public string CListServ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "cSitTrib")]
        public string CSitTrib { get; set; }
    }
}
