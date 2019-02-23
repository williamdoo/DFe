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
	public class ICMSSN101
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
        /// Origem da mercadoria CF-e
        /// <para>0 - Nacional</para>
        /// <para>1 - Estrangeira - Importação direta</para>
        /// <para>2 - Estrangeira - Adquirida no meracado interno</para>
        /// </summary>
        [XmlElement(elementName: "Orig")]
        public string OrigCFe { get; set; }

        /// <summary>
        /// Código de Situação da Operação – Simples Nacional
        /// <para>
        ///     101- Tributada pelo Simples Nacional com permissão 
        ///     de crédito. (v.2.0)
        /// </para>
        /// </summary>
        [XmlElement(elementName: "CSOSN")]
        public string CSOSN { get; set; }

        /// <summary>
        /// Alíquota aplicável de cálculo do crédito (Simples Nacional).
        /// </summary>
        [XmlElement(elementName: "pCredSN")]
        public string PCredSN { get; set; }

        /// <summary>
        /// Valor crédito do ICMS que pode ser aproveitado nos termos 
        /// do art. 23 da LC 123 (Simples Nacional)
        /// </summary>
        [XmlElement(elementName: "vCredICMSSN")]
        public string VCredICMSSN { get; set; }
    }
}
