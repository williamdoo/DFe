using System.Collections.Generic;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class InfAdic
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "infAdFisco")]
        public string InfAdFisco { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "infCpl")]
        public string InfCpl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "obsCont")]
        public List<ObsCont> ObsCont { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "obsFisco")]
        public List<ObsFisco> ObsFisco { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "procRef")]
        public List<ProcRef> ProcRef { get; set; }
    }
}
