using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Total
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "ICMSTot")]
        public ICMSTot ICMSTot { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "ISSQNtot")]
        public ISSQNtot ISSQNtot { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "retTrib")]
        public RetTrib RetTrib { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "DescAcrEntr")]
        public DescAcrEntr DescAcrEntr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vCFeLei12741")]
        public string VCFeLei12741 { get; set; }
    }
}
