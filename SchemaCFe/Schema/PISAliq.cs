using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class PISAliq
    {
        /// <summary>
        /// Código de Situação Tributária do PIS
        /// </summary>
        [XmlElement(ElementName = "CST")]
        public string CST { get; set; }

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
        /// Valor do PIS 
        /// </summary>
        [XmlElement(ElementName = "vPIS")]
        public string VPIS { get; set; }
    }
}