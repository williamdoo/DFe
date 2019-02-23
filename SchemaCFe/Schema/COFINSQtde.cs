using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class COFINSQtde
    {
        /// <summary>
        /// Código de Situação Tributária do COFINS 
        /// </summary>
        [XmlElement(ElementName = "CST")]
        public string CST { get; set; }

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