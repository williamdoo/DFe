using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class Prod
    {
        /// <summary> 
        /// Código do produto ou serviço
        /// </summary>
        [XmlElement(ElementName = "cProd")]
        public string CProd { get; set; }

        /// <summary>
        /// GTIN (Global Trade Item Number) do produto, antigo código EAN ou código de barras
        /// </summary>
        [XmlElement(ElementName = "cEAN")]
        public string CEAN { get; set; }

        /// <summary>
        /// Descrição do produto ou serviço
        /// </summary>
        [XmlElement(ElementName = "xProd")]
        public string XProd { get; set; }

        /// <summary>
        /// Código NCM com 8 dígitos ou 2 dígitos(gênero)
        /// </summary>
        [XmlElement(ElementName = "NCM")]
        public string NCM { get; set; }

        /// <summary>
        /// Código Especificador da Substituição Tributária
        /// </summary>
        [XmlElement(ElementName = "CEST")]
        public string CEST { get; set; }

        /// <summary>
        /// Código Fiscal de Operações e Prestações
        /// </summary>
        [XmlElement(ElementName = "CFOP")]
        public string CFOP { get; set; }

        /// <summary>
        /// Unidade Comercial 
        /// </summary>
        [XmlElement(ElementName = "uCom")]
        public string UCom { get; set; }

        /// <summary>
        /// Quantidade Comercial
        /// </summary>
        [XmlElement(ElementName = "qCom")]
        public string QCom { get; set; }

        /// <summary>
        ///Valor Unitário de Comercialização
        /// </summary>
        [XmlElement(ElementName = "vUnCom")]
        public string VUnCom { get; set; }

        /// <summary>
        /// Valor Bruto dos Produtos ou Serviços 
        /// </summary>
        [XmlElement(ElementName = "vProd")]
        public string VProd { get; set; }

        /// <summary>
        /// Regra de cálculo
        /// </summary>
        [XmlElement(ElementName = "indRegra")]
        public string IndRegra { get; set; }

        /// <summary>
        /// Valor do Desconto sobre item
        /// </summary>
        [XmlElement(ElementName = "vDesc")]
        public string VDesc { get; set; }

        /// <summary>
        /// Outras despesas acessórias sobre item
        /// </summary>
        [XmlElement(ElementName = "vOutro")]
        public string VOutro { get; set; }

        /// <summary>
        /// Valor líquido do Item
        /// </summary>
        [XmlElement(ElementName = "vItem")]
        public string VItem { get; set; }

        /// <summary>
        /// Rateio do desconto sobre subtotal
        /// </summary>
        [XmlElement(ElementName = "vRatDesc")]
        public string VRatDesc { get; set; }

        /// <summary>
        /// Rateio do acréscimo sobre subtotal
        /// </summary>
        [XmlElement(ElementName = "vRatAcr")]
        public string VRatAcr { get; set; }

        /// <summary>
        /// Grupo do campo de uso livre do Fisco
        /// </summary>
        [XmlElement(ElementName = "obsFiscoDet")]
        public ObsFiscoDet ObsFiscoDet { get; set; }
    }
}