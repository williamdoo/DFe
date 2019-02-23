using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class ICMSTot
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vBC")]
        public string VBC { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vICMS")]
        public string VICMS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vICMSDeson")]
        public string VICMSDeson { get; set; }

        /// <summary>
        /// Valor Total do FCP (Fundo de Combate à Pobreza) 
        /// </summary>
        [XmlElement(elementName: "vFCP")]
        public string VFCP { get; set; }

        /// <summary>
        /// Valor total do ICMS relativo Fundo de Combate à Pobreza (FCP) da UF de destino
        /// </summary>
        [XmlElement(elementName: "vFCPUFDest")]
        public string VFCPUFDest { get; set; }

        /// <summary>
        /// Valor total do ICMS Interestadual para a UF de destino
        /// </summary>
        [XmlElement(elementName: "vICMSUFDest")]
        public string VICMSUFDest { get; set; }

        /// <summary>
        /// Valor total do ICMS Interestadual para a UF do remetente
        /// </summary>
        [XmlElement(elementName: "vICMSUFRemet")]
        public string VICMSUFRemet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vBCST")]
        public string VBCST { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vST")]
        public string VST { get; set; }

        /// <summary>
        /// Valor Total do FCP (Fundo de Combate à Pobreza) retido por substituição tributária 
        /// </summary>
        [XmlElement(elementName: "vFCPST")]
        public string VFCPST { get; set; }

        /// <summary>
        /// Valor Total do FCP retido anteriormente por Substituição Tributária
        /// </summary>
        [XmlElement(elementName: "vFCPSTRet")]
        public string VFCPSTRet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vProd")]
        public string VProd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vFrete")]
        public string VFrete { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vSeg")]
        public string VSeg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vDesc")]
        public string VDesc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vII")]
        public string VII { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vIPI")]
        public string VIPI { get; set; }

        /// <summary>
        /// Valor Total do IPI devolvido 
        /// <para>
        /// Deve ser informado quando preenchido o Grupo Tributos Devolvidos na emissão de nota finNFe=4 (devolução) nas operações com não contribuintes do IPI. Corresponde ao total da soma dos campos id:UA04.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "vIPIDevol")]
        public string VIPIDevol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vPIS")]
        public string VPIS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vCOFINS")]
        public string VCOFINS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vOutro")]
        public string VOutro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vNF")]
        public string VNF { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vTotTrib")]
        public string VTotTrib { get; set; }
    }
}
