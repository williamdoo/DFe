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
	public class ICMSPart
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
        ///     10 - Tributada e com cobrança do ICMS por 
        ///     substituição tributária
        /// </para>
        /// <para>90 – Outros</para>
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
        /// Percentual para determinação do valor da Base de 
        /// Cálculo da operação própria. (v2.0)
        /// </summary>
        [XmlElement(elementName: "pBCOp")]
        public string PBCOp { get; set; }

        /// <summary>
        /// Sigla da UF para qual é devido o ICMS ST da operação. (v2.0)
        /// </summary>
        [XmlElement(elementName: "UFST")]
        public string UFST { get; set; }
    }
}
