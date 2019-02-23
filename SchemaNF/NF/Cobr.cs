using System.Collections.Generic;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Cobr
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "fat")]
        public Fat Fat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "dup")]
        public List<Dup> Dup { get; set; }
    }
}
