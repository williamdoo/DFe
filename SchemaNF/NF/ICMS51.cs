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
	public class ICMS51
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
        /// Tributação pelo ICMS 51 - Diferimento
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
        [XmlElement(elementName: "modBC")]
        public string ModBC { get; set; }

        /// <summary>
        /// Percentual da Redução de BC
        /// </summary>
        [XmlElement(elementName: "pRedBC")]
        public string PRedBC { get; set; }

        /// <summary>
        /// Valor da BC do ICMS
        /// </summary>
        [XmlElement(elementName: "vBC")]
        public string VBC { get; set; }

        /// <summary>
        /// Alíquota do imposto
        /// </summary>
        [XmlElement(elementName: "pICMS")]
        public string PICMS { get; set; }

        /// <summary>
        /// Valor como se não tivesse o diferiment
        /// </summary>
        [XmlElement(elementName: "vICMSOp")]
        public string VICMSOp { get; set; }

        /// <summary>
        /// No caso de diferimento total, informar o percentual de diferimento "100"
        /// </summary>
        [XmlElement(elementName: "pDif")]
        public string PDif { get; set; }

        /// <summary>
        /// Informar o valor realmente devido
        /// </summary>
        [XmlElement(elementName: "vICMSDif")]
        public string VICMSDif { get; set; }

        /// <summary>
        /// Valor do ICMS
        /// </summary>
        [XmlElement(elementName: "vICMS")]
        public string VICMS { get; set; }

        /// <summary>
        /// Valor da Base de Cálculo do FCP
        /// </summary>
        [XmlElement(elementName: "vBCFCP")]
        public string VBCFCP { get; set; }

        /// <summary>
        /// Percentual do Fundo de Combate à Pobreza (FCP)
        /// </summary>
        [XmlElement(elementName: "pFCP")]
        public string PFCP { get; set; }

        /// <summary>
        /// Valor do Fundo de Combate à Pobreza (FCP) 
        /// </summary>
        [XmlElement(elementName: "vFCP")]
        public string VFCP { get; set; }
    }
}