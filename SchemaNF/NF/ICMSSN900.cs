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
	public class ICMSSN900
    {
        /// <summary>
        /// Origem da mercadoria
        /// </summary>
        [XmlElement(elementName: "orig")]
        public string Orig { get; set; }

        /// <summary>
        /// Origem da mercadoria CFe
        /// <para>0 - Nacional</para>
        /// <para>1 - Estrangeira - Importação direta</para>
        /// <para>2 - Estrangeira - Adquirida no meracado interno</para>
        /// </summary>
        [XmlElement(elementName: "OrigCFe")]
        public string OrigCFe { get; set; }

        /// <summary>
        /// Código de Situação da Operação – SIMPLES NACIONA
        /// </summary>
        [XmlElement(elementName: "CSOSN")]
        public string CSOSN { get; set; }

        /// <summary>
        /// Modalidade de determinação da BC do ICMS 
        /// </summary>
        [XmlElement(elementName: "modBC")]
        public string ModBC { get; set; }

        /// <summary>
        /// Valor da BC do ICMS
        /// </summary>
        [XmlElement(elementName: "vBC")]
        public string VBC { get; set; }

        /// <summary>
        /// Percentual da Redução de BC
        /// </summary>
        [XmlElement(elementName: "pRedBC")]
        public string PRedBC { get; set; }

        /// <summary>
        /// Alíquota do imposto
        /// </summary>
        [XmlElement(elementName: "pICMS")]
        public string PICMS { get; set; }

        /// <summary>
        /// Valor do ICMS 
        /// </summary>
        [XmlElement(elementName: "vICMS")]
        public string VICMS { get; set; }

        /// <summary>
        /// Modalidade de determinação da BC do ICMS ST 
        /// </summary>
        [XmlElement(elementName: "modBCST")]
        public string ModBCST { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "pMVAST")]
        public string PMVAST { get; set; }

        /// <summary>
        /// Percentual da margem de valor Adicionado do ICMS S
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

        /// <summary>
        /// Alíquota aplicável de cálculo do crédito (Simples Nacional)
        /// </summary>
        [XmlElement(elementName: "pCredSN")]
        public string PCredSN { get; set; }

        /// <summary>
        /// Valor crédito do ICMS que pode ser aproveitado nos termos do art. 23 da LC 123/2006 (Simples Nacional) 
        /// </summary>
        [XmlElement(elementName: "vCredICMSSN")]
        public string VCredICMSSN { get; set; }
    }
}
