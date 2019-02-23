using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class ICMS
    {
        /// <summary>
        /// Campo cRegTrib=3 – Regime Normal Grupo de Tributação do ICMS= 00, 20, 90
        /// </summary>
        [XmlElement(ElementName = "ICMS00")]
        public ICMS00 ICMS00 { get; set; }

        /// <summary>
        /// Campo cRegTrib=3 – Regime Normal Grupo de Tributação do ICMS = 40, 41, 60
        /// </summary>
        [XmlElement(ElementName = "ICMS40")]
        public ICMS40 ICMS40 { get; set; }

        /// <summary>
        /// Campo cRegTrib=1 – Simples Nacional e CSOSN = 102, 300, 400, 500
        /// </summary>
        [XmlElement(ElementName = "ICMSSN102")]
        public ICMSSN102 ICMSSN102 { get; set; }

        /// <summary>
        /// Campo cRegTrib=1 – Simples Nacional e CSOSN = 900
        /// </summary>
        [XmlElement(ElementName = "ICMSSN900")]
        public ICMSSN900 ICMSSN900 { get; set; }
    }
}