using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class PISST
    {
        /// <summary>
        /// Valor da Base de Cálculo do PIS 
        /// </summary>
        [XmlElement(ElementName = "vBC")]
        public string VBC { get; set; }

        /// <summary>
        /// Alíquota do PIS (em percentual)
        /// </summary>
        [XmlElement(ElementName = "pPIS")]
        public string PPIS { get; set; }

        /// <summary>
        /// Quantidade Vendida
        /// </summary>
        [XmlElement(ElementName = "qBCProd")]
        public string QBCProd { get; set; }

        /// <summary>
        /// Alíquota do PIS (em reais)
        /// </summary>
        [XmlElement(ElementName = "vAliqProd")]
        public string VAliqProd { get; set; }

        /// <summary>
        /// Valor do PIS 
        /// </summary>
        [XmlElement(ElementName = "vPIS")]
        public string VPIS { get; set; }
    }
}