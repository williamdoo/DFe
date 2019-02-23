using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class Det
    {

        /// <summary>
        /// Número do item
        /// </summary>
        [XmlAttribute(AttributeName = "nItem")]
        public string NItem { get; set; }

        /// <summary>
        /// TAG de grupo do detalhamento de Produtos e Serviços do CF-e
        /// </summary>
        [XmlElement(ElementName = "prod")]
        public Prod Prod { get; set; }

        /// <summary>
        /// Grupo de Tributos incidentes no Produto ou Serviço
        /// </summary>
        [XmlElement(ElementName = "imposto")]
        public Imposto Imposto { get; set; }

        /// <summary>
        /// Informações Adicionais do Produto
        /// </summary>
        [XmlElement(ElementName = "infAdProd")]
        public string InfAdProd { get; set; }
    }
} 