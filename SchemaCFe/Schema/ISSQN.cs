using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class ISSQN
    {
        /// <summary>
        /// Valor das deduções para ISSQN
        /// </summary>
        [XmlElement(ElementName = "vDeducISSQN")]
        public string VDeducISSQN { get; set; }

        /// <summary>
        /// Valor da Base de Cálculo do ISSQN
        /// </summary>
        [XmlElement(ElementName = "vBC")]
        public string VBC { get; set; }

        /// <summary>
        /// Alíquota do ISSQN
        /// </summary>
        [XmlElement(ElementName = "vAliq")]
        public string VAliq { get; set; }

        /// <summary>
        /// Valor do ISSQN
        /// </summary>
        [XmlElement(ElementName = "vISSQN")]
        public string VISSQN { get; set; }

        /// <summary>
        /// Código do município de ocorrência do fato gerador do ISSQN
        /// </summary>
        [XmlElement(ElementName = "cMunFG")]
        public string CMunFG { get; set; }

        /// <summary>
        /// Item da Lista de Serviços 
        /// </summary>
        [XmlElement(ElementName = "cListServ")]
        public string CListServ { get; set; }

        /// <summary>
        /// Codigo de tributação pelo ISSQN do municipio
        /// </summary>
        [XmlElement(ElementName = "cServTribMun")]
        public string CServTribMun { get; set; }

        /// <summary>
        /// Natureza da Operação de ISSQN
        /// </summary>
        [XmlElement(ElementName = "cNatOp")]
        public string CNatOp { get; set; }

        /// <summary>
        /// Indicador de Incentivo Fiscal do ISSQN
        /// </summary>
        [XmlElement(ElementName = "indIncFisc")]
        public string IndIncFisc { get; set; }
    }
}