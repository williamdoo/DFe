using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class ISSQNtot
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vServ")]
        public string VServ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vBC")]
        public string VBC { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vISS")]
        public string VISS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vPIS")]
        public string VPIS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vCOFINS")]
        public string VCOFINS { get; set; }
    }
}
