using System.Collections.Generic;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Transp
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "modFrete")]
        public string ModFrete { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "transporta")]
        public Transporta Transporta { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "retTransp")]
        public RetTransp RetTransp { get; set; }

        /// <summary>
        /// Grupo Veículo
        /// </summary>
        [XmlElement(elementName: "veicTransp")]
        public VeicTransp VeicTransp { get; set; }

        /// <summary>
        /// Grupo Reboque
        /// </summary>
        [XmlElement(elementName: "reboque")]
        public Reboque Reboque { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vagao")]
        public string Vagao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "balsa")]
        public string balsa { get; set; }

        /// <summary>
        /// Grupo Volumes
        /// </summary>
        [XmlElement(elementName: "vol")]
        public List<Vol> Vol { get; set; }
    }
}
