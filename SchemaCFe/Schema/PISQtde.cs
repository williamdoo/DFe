using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class PISQtde
    {
        /// <summary>
        /// Código de Situação Tributária do PIS 
        /// </summary>
        [XmlElement(ElementName = "CST")]
        public string CST { get; set; }

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