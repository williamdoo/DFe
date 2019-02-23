using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Det
    {
        /// <summary>
        /// Número do item
        /// </summary>
        [XmlAttribute(attributeName: "nItem")]
        public string NItem { get; set; }

        /// <summary>
        /// TAG de grupo do detalhamento de Produtos e Serviços da NF-e
        /// </summary>
        [XmlElement(elementName: "prod")]
        public Prod Prod { get; set; }

        /// <summary>
        /// Grupo de Tributos incidentes no Produto ou Serviço
        /// </summary>
        [XmlElement(elementName: "imposto")]
        public Imposto Imposto { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "infAdProd")]
        public string InfAdProd { get; set; }
    }
}
