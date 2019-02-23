using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    /// <summary>
	/// 
	/// </summary>
	public class COFINSOutr
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "CST")]
        public string CST { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vBC")]
        public string VBC { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "pCOFINS")]
        public string PCOFINS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "qBCProd")]
        public string QBCProd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vAliqProd")]
        public string VAliqProd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vCOFINS")]
        public string VCOFINS { get; set; }
    }
}
