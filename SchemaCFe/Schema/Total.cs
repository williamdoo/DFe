using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class Total
    {
        /// <summary>
        /// Grupo de Valores Totais referentes ao ICMS 
        /// </summary>
        [XmlElement(ElementName = "ICMSTot")]
        public ICMSTot ICMSTot { get; set; }

        /// <summary>
        /// Valor Total do CFe
        /// </summary>
        [XmlElement(ElementName = "vCFe")]
        public string VCFe { get; set; }

        /// <summary>
        /// Grupo de Valores Totais referentes ao ISSQN
        /// </summary>
        [XmlElement(ElementName = "ISSQNtot")]
        public ISSQNtot ISSQNtot { get; set; }

        /// <summary>
        /// Grupo de valores de entrada de Desconto/Acréscimo sobre Subtotal
        /// </summary>
        [XmlElement(ElementName = "DescAcrEntr")]
        public DescAcrEntr DescAcrEntr { get; set; }

        /// <summary>
        /// Valor aproximado dos tributos do CFe-SAT – Lei 12741/12
        /// </summary>
        [XmlElement(ElementName = "vCFeLei12741")]
        public string vCFeLei12741 { get; set; }

    }
} 