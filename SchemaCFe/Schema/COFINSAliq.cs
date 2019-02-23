using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class COFINSAliq
    {
        /// <summary>
        /// Código de Situação Tributária do COFINS
        /// </summary>
        [XmlElement(ElementName = "CST")]
        public string CST { get; set; }

        /// <summary>
        /// Valor da Base de Cálculo do COFINS
        /// </summary>
        [XmlElement(ElementName = "vBC")]
        public string VBC { get; set; }

        /// <summary>
        /// Alíquota do COFINS (em percentual)
        /// </summary>
        [XmlElement(ElementName = "pCOFINS")]
        public string PCOFINS { get; set; }

        /// <summary>
        /// Valor do COFINS 
        /// </summary>
        [XmlElement(ElementName = "vCOFINS")]
        public string VCOFINS { get; set; }
    }
}