using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class COFINSST
    {
        /// <summary>
        /// Valor da Base de Cálculo do COFINS 
        /// </summary>
        [XmlElement(ElementName = "vBC")]
        public string VBC { get; set; }

        /// <summary>
        /// Alíquota do COFINS (em percentual)
        /// </summary>
        [XmlElement(ElementName = "pCOFINS")]
        public string PCOFINS { get; set; }

        /// <summary>
        /// Quantidade Vendida
        /// </summary>
        [XmlElement(ElementName = "qBCProd")]
        public string QBCProd { get; set; }

        /// <summary>
        /// Alíquota do COFINS (em reais)
        /// </summary>
        [XmlElement(ElementName = "vAliqProd")]
        public string VAliqProd { get; set; }

        /// <summary>
        /// Valor do COFINS 
        /// </summary>
        [XmlElement(ElementName = "vCOFINS")]
        public string VCOFINS { get; set; }
    }
}