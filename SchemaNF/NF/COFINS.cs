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
	public class COFINS
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "COFINSAliq")]
        public COFINSAliq COFINSAliq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "COFINSQtde")]
        public COFINSQtde COFINSQtde { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "COFINSNT")]
        public COFINSNT COFINSNT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "COFINSOutr")]
        public COFINSOutr COFINSOutr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "COFINSST")]
        public COFINSST COFINSST { get; set; }
    }
}
