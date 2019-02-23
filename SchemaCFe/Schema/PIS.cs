using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class PIS
    {
        /// <summary>
        /// Grupo de PIS tributado pela alíquota
        /// </summary>
        [XmlElement(ElementName = "PISAliq")]
        public PISAliq PISAliq { get; set; }

        /// <summary>
        /// Grupo de PIS tributado por Qtde
        /// </summary>
        [XmlElement(ElementName = "PISQtde")]
        public PISQtde PISQtde { get; set; }

        /// <summary>
        /// Grupo de PIS não tributado
        /// </summary>
        [XmlElement(ElementName = "PISNT")]
        public PISNT PISNT { get; set; }

        /// <summary>
        /// Grupo de PIS para contribuinte do SIMPLES NACIONAL
        /// </summary>
        [XmlElement(ElementName = "PISSN")]
        public PISSN PISSN { get; set; }

        /// <summary> 
        /// Grupo de PIS Outras Operações
        /// </summary>
        [XmlElement(ElementName = "PISOutr")]
        public PISOutr PISOutr { get; set; }

        /// <summary>
        /// Grupo de PIS Substituição Tributária
        /// </summary>
        [XmlElement(ElementName = "PISST")]
        public PISST PISST { get; set; }
    }
}