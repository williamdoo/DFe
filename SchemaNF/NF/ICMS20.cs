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
	public class ICMS20
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
        /// <para>20 - Com redução de base de cálculo</para>
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
