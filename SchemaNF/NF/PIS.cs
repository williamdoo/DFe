using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class PIS
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "PISAliq")]
        public PISAliq PISAliq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "PISQtde")]
        public PISQtde PISQtde { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "PISNT")]
        public PISNT PISNT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "PISOutr")]
        public PISOutr PISOutr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "PISST")]
        public PISST PISST { get; set; }
    }
}
