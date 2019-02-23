using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class ICMSUFDest
    {
        /// <summary>
        /// Valor da BC do ICMS na UF de destino
        /// </summary>
        [XmlElement(elementName: "vBCUFDest")]
        public string VBCUFDest { get; set; }
        /// <summary>
        /// Percentual do ICMS relativo ao Fundo de Combate à Pobreza (FCP) na UF de destino
        /// </summary>
        [XmlElement(elementName: "pFCPUFDest")]
        public string PFCPUFDest { get; set; }
        /// <summary>
        /// Alíquota interna da UF de destino
        /// </summary>
        [XmlElement(elementName: "pICMSUFDest")]
        public string PICMSUFDest { get; set; }
        /// <summary>
        /// Alíquota interestadual das UF envolvidas
        /// </summary>
        [XmlElement(elementName: "pICMSInter")]
        public string PICMSInter { get; set; }
        /// <summary>
        /// Percentual provisório de partilha do ICMS Interestadual
        /// </summary>
        [XmlElement(elementName: "pICMSInterPart")]
        public string PICMSInterPart { get; set; }
        /// <summary>
        /// Valor do ICMS relativo ao Fundo de Combate à Pobreza (FCP) da UF de destino
        /// </summary>
        [XmlElement(elementName: "vFCPUFDest")]
        public string VFCPUFDest { get; set; }
        /// <summary>
        /// Valor do ICMS Interestadual para a UF de destino
        /// </summary>
        [XmlElement(elementName: "vICMSUFDest")]
        public string VICMSUFDest { get; set; }
        /// <summary>
        /// Valor do ICMS Interestadual para a UF do remetente
        /// </summary>
        [XmlElement(elementName: "vICMSUFRemet")]
        public string VICMSUFRemet { get; set; }
    }
}
