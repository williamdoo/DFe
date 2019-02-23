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
	public class ICMS30
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
        /// Tributação do ICMS:
        /// <para>
        ///     30 - Isenta ou não tributada e com cobrança do 
        ///     ICMS por substituição tributária
        /// </para>
        /// </summary>
        [XmlElement(elementName: "CST")]
        public string CST { get; set; }

        /// <summary>
        /// Modalidade de determinação da BC do ICMS
        /// <para>0 - Margem Valor Agregado (%)</para>
        /// <para>1 - Pauta (Valor)</para>
        /// <para>2 - Preço Tabelado Máx. (valor)</para>
        /// <para>3 - valor da operação</para>
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
        /// Valor do ICMS desonerado
        /// </summary>
        [XmlElement(elementName: "vICMSDeson")]
        public string VICMSDeson { get; set; }

        /// <summary>
        /// Motivo da desoneração do ICMS
        /// </summary>
        [XmlElement(elementName: "motDesICMS")]
        public string MotDesICMS { get; set; }
    }
}
