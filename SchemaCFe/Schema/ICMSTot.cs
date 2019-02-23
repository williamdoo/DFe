using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class ICMSTot
    {
        /// <summary>
        /// Valor Total do ICMS
        /// </summary>
        [XmlElement(ElementName = "vICMS")]
        public string VICMS { get; set; }

        /// <summary>
        /// Valor Total dos produtos e serviços
        /// </summary>
        [XmlElement(ElementName = "vProd")]
        public string VProd { get; set; }

        /// <summary>
        /// Valor Total dos Descontos sobre Item
        /// </summary>
        [XmlElement(ElementName = "vDesc")]
        public string VDesc { get; set; }

        /// <summary>
        /// Valor Total do PIS
        /// </summary>
        [XmlElement(ElementName = "vPIS")]
        public string VPIS { get; set; }

        /// <summary>
        /// Valor Total do COFINS
        /// </summary>
        [XmlElement(ElementName = "vCOFINS")]
        public string VCOFINS { get; set; }

        /// <summary>
        /// Valor Total do PISST 
        /// </summary>
        [XmlElement(ElementName = "vPISST")]
        public string VPISST { get; set; }

        /// <summary>
        /// Valor Total do COFINS-ST
        /// </summary>
        [XmlElement(ElementName = "vCOFINSST")]
        public string VCOFINSST { get; set; }

        /// <summary>
        /// Valor Total de Outras Despesas acessórias sobre Item
        /// </summary>
        [XmlElement(ElementName = "vOutro")]
        public string VOutro { get; set; }

    }
}