using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class COFINS
    {
        /// <summary>
        /// Grupo de PIS tributado pela alíquota
        /// </summary>
        [XmlElement(ElementName = "COFINSAliq")]
        public COFINSAliq COFINSAliq { get; set; }

        /// <summary>
        /// Grupo de PIS tributado por Qtde
        /// </summary>
        [XmlElement(ElementName = "COFINSQtde")]
        public COFINSQtde COFINSQtde { get; set; }

        /// <summary>
        /// Grupo de PIS não tributado
        /// </summary>
        [XmlElement(ElementName = "COFINSNT")]
        public COFINSNT COFINSNT { get; set; }

        /// <summary>
        /// Grupo de PIS para contribuinte do SIMPLES NACIONAL
        /// </summary>
        [XmlElement(ElementName = "COFINSSN")]
        public COFINSSN COFINSSN { get; set; }

        /// <summary> 
        /// Grupo de PIS Outras Operações
        /// </summary>
        [XmlElement(ElementName = "COFINSOutr")]
        public COFINSOutr COFINSOutr { get; set; }

        /// <summary>
        /// Grupo de PIS Substituição Tributária
        /// </summary>
        [XmlElement(ElementName = "COFINSST")]
        public COFINSST COFINSST { get; set; }
    }
}