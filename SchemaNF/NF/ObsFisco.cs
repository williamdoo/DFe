using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class ObsFisco
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "xCampo")]
        public string XCampo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "xTexto")]
        public string XTexto { get; set; }
    }
}
