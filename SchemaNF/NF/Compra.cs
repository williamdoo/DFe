using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Compra
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "xNEmp")]
        public string XNEmp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "xPed")]
        public string XPed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "xCont")]
        public string XCont { get; set; }
    }
}
