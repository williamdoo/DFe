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
	public class ICMS60
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
        /// Origem da mercadoria CFe
        /// <para>0 - Nacional</para>
        /// <para>1 - Estrangeira - Importação direta</para>
        /// <para>2 - Estrangeira - Adquirida no meracado interno</para>
        /// </summary>
        [XmlElement(elementName: "Orig")]
        public string OrigCFe { get; set; }

        /// <summary>
        /// Tributação do ICMS:
        /// <para>
        ///     Tributação pelo ICMS 60 - ICMS cobrado
        ///     anteriormente por substituição tributária
        /// </para>
        /// </summary>
        [XmlElement(elementName: "CST")]
        public string CST { get; set; }

        /// <summary>
        /// Valor da BC do ICMS ST retido
        /// </summary>
        [XmlElement(elementName: "vBCSTRet")]
        public string VBCSTRet { get; set; }

        /// <summary>
        /// Alíquota suportada pelo Consumidor Final 
        /// <para>
        /// Deve ser informada a alíquota do cálculo do ICMS-ST, já incluso o FCP caso incida sobre a mercadoria.Exemplo: alíquota da mercadoria na venda ao consumidor final = 18 % e 2% de FCP.A alíquota a ser informada no campo pST deve ser 20%. 
        /// </para>
        /// </summary>
        [XmlElement(elementName: "pST")]
        public string PST { get; set; }

        /// <summary>
        /// Valor do ICMS ST retido
        /// </summary>
        [XmlElement(elementName: "vICMSSTRet")]
        public string VICMSSTRet { get; set; }

        /// <summary>
        /// Valor da Base de Cálculo do FCP retido anteriormente por ST 
        /// </summary>
        [XmlElement(elementName: "vBCFCPSTRet")]
        public string VBCFCPSTRet { get; set; }

        /// <summary>
        /// Percentual do FCP retido anteriormente por Substituição Tributária 
        /// </summary>
        [XmlElement(elementName: "pFCPSTRet")]
        public string PFCPSTRet { get; set; }

        /// <summary>
        /// Valor do FCP retido por Substituição Tributária 
        /// </summary>
        [XmlElement(elementName: "vFCPSTRet")]
        public string VFCPSTRet { get; set; }
    }
}
