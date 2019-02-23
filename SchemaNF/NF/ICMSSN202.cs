using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    /// <summary>
    /// 
    /// </summary>
    /// <summary>
	/// 
	/// </summary>
	public class ICMSSN202
    {
        /// <summary>
        /// Origem da mercadoria
        /// </summary>
        [XmlElement(elementName: "orig")]
        public string Orig { get; set; }

        /// <summary>
        /// Código de Situação da Operação – Simples Nacional 
        /// </summary>
        [XmlElement(elementName: "CSOSN")]
        public string CSOSN { get; set; }

        /// <summary>
        /// Modalidade de determinação da BC do ICMS ST 
        /// </summary>
        [XmlElement(elementName: "modBCST")]
        public string ModBCST { get; set; }

        /// <summary>
        /// Percentual da margem de valor Adicionado do ICMS ST 
        /// </summary>
        [XmlElement(elementName: "pMVAST")]
        public string PMVAST { get; set; }

        /// <summary>
        /// Percentual da Redução de BC do ICMS ST 
        /// </summary>
        [XmlElement(elementName: "pRedBCST")]
        public string PRedBCST { get; set; }

        /// <summary>
        /// Valor da BC do ICMS ST
        /// </summary>
        [XmlElement(elementName: "vBCST")]
        public string VBCST { get; set; }

        /// <summary>
        /// Alíquota do imposto do ICMS ST
        /// </summary>
        [XmlElement(elementName: "pICMSST")]
        public string PICMSST { get; set; }

        /// <summary>
        /// Valor do ICMS ST 
        /// </summary>
        [XmlElement(elementName: "vICMSST")]
        public string VICMSST { get; set; }

        /// <summary>
        /// Valor da Base de Cálculo do FCP retido por Substituição Tributária 
        /// </summary>
        [XmlElement(elementName: "vBCFCPST")]
        public string VBCFCPST { get; set; }

        /// <summary>
        /// Percentual do FCP retido por Substituição Tributária 
        /// </summary>
        [XmlElement(elementName: "pFCPST")]
        public string PFCPST { get; set; }

        /// <summary>
        /// Valor do FCP retido por Substituição Tributária 
        /// </summary>
        [XmlElement(elementName: "vFCPST")]
        public string VFCPST { get; set; }
    }
}
