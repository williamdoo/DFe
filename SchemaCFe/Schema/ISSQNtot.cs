using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class ISSQNtot
    {
        /// <summary>
        /// Valor Total da Base de Cálculo do ISSQN
        /// </summary>
        [XmlElement(ElementName = "vBC")]
        public string VBC { get; set; }

        /// <summary>
        /// Valor Total do ISS
        /// </summary>
        [XmlElement(ElementName = "vISS")]
        public string VFISS { get; set; }

        /// <summary>
        /// Valor Total do PIS sobre serviços
        /// </summary>
        [XmlElement(ElementName = "vPIS")]
        public string VPIS { get; set; }

        /// <summary>
        /// Valor Total do COFINS sobre serviços
        /// </summary>
        [XmlElement(ElementName = "vCOFINS")]
        public string VCOFINS { get; set; }

        /// <summary>
        /// Valor Total do PISST sobre serviços
        /// </summary>
        [XmlElement(ElementName = "vPISST")]
        public string VPISST { get; set; }

        /// <summary>
        /// Valor Total do COFINS-ST sobre serviços
        /// </summary>
        [XmlElement(ElementName = "vCOFINSST")]
        public string VCOFINSST { get; set; }
    }
}