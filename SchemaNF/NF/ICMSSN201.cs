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
	public class ICMSSN201
    {
        /// <summary>
        /// Origem da mercadoria
        /// <para>0 - Nacional</para>
        /// <para>1 - Estrangeira - Importação direta</para>
        /// <para>2 - Estrangeira - Adquirida no meracado interno</para>
        /// </summary>
        [XmlElement(elementName: "orig")]
        public string Orig { get; set; }

        /// <summary>
        /// Código de Situação da Operação – Simples Nacional
        /// <para>
        ///     201- Tributada pelo Simples Nacional com permissão de
        ///     crédito e com cobrança do ICMS por Substituição 
        ///     Tributária (v.2.0)
        /// </para>
        /// </summary>
        [XmlElement(elementName: "CSOSN")]
        public string CSOSN { get; set; }

        /// <summary>
        /// Modalidade de determinação da BC do ICMS ST
        /// <para>0 – Preço tabelado ou máximo sugerido</para>
        /// <para>1 - Lista Negativa (valor)</para>
        /// <para>2 - Lista Positiva (valor)</para>
        /// <para>3 - Lista Neutra (valor)</para>
        /// <para>4 - Margem Valor Agregado (%)</para>
        /// <para>5 - Pauta (valor)</para>
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
        /// Valor do ICMS ST retido
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
        /// Alíquota aplicável de cálculo do crédito (SIMPLES NACIONAL).
        /// </summary>
        [XmlElement(elementName: "pCredSN")]
        public string PCredSN { get; set; }

        /// <summary>
        /// Valor crédito do ICMS que pode ser aproveitado nos
        /// termos do art. 23 da LC 123 (SIMPLES NACIONAL)
        /// </summary>
        [XmlElement(elementName: "vCredICMSSN")]
        public string VCredICMSSN { get; set; }
    }
}
