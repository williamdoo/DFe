﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    /// <summary>
	/// 
	/// </summary>
	public class PISQtde
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "CST")]
        public string CST { get; set; }

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
        [XmlElement(elementName: "vPIS")]
        public string VPIS { get; set; }
    }
}
