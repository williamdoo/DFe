using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class ICMS
    {
        /// <summary>
        /// Grupo de Tributação do ICMS – 00 – Tributada integralmente
        /// </summary>
        [XmlElement(elementName: "ICMS00")]
        public ICMS00 ICMS00 { get; set; }

        /// <summary>
        /// Grupo de Tributação do ICMS - 10 - Tributada e 
        /// com cobrança do ICMS por substituição tributária
        /// </summary>
        [XmlElement(elementName: "ICMS10")]
        public ICMS10 ICMS10 { get; set; }

        /// <summary>
        /// Grupo de Tributação do ICMS – 20 - Com redução de 
        /// base de cálculo
        /// </summary>
        [XmlElement(elementName: "ICMS20")]
        public ICMS20 ICMS20 { get; set; }

        /// <summary>
        /// Grupo de Tributação do ICMS – 30 - Isenta ou não 
        /// tributada e com cobrança do ICMS por substituição tributária
        /// </summary>
        [XmlElement(elementName: "ICMS30")]
        public ICMS30 ICMS30 { get; set; }

        /// <summary>
        /// Grupo de Tributação do ICMS
        /// <para>40 - Isenta</para>
        /// <para>41 - Não tributada</para>
        /// <para>50 - Suspensão</para>
        /// </summary>
        [XmlElement(elementName: "ICMS40")]
        public ICMS40 ICMS40 { get; set; }

        /// <summary>
        /// Grupo de Tributação do ICMS – 51 - Diferimento
        /// A exigência do preenchimento das informações do ICMS
        /// diferido fica a critério de cada UF.
        /// </summary>
        [XmlElement(elementName: "ICMS51")]
        public ICMS51 ICMS51 { get; set; }

        /// <summary>
        /// Grupo de Tributação do ICMS – 60 - ICMS cobrado 
        /// anteriormente por substituição tributária
        /// </summary>
        [XmlElement(elementName: "ICMS60")]
        public ICMS60 ICMS60 { get; set; }

        /// <summary>
        /// Grupo de Tributação do ICMS - 70 - Com redução de 
        /// base de cálculo e cobrança do ICMS por substituição 
        /// tributária
        /// </summary>
        [XmlElement(elementName: "ICMS70")]
        public ICMS70 ICMS70 { get; set; }

        /// <summary>
        /// Grupo Tributação do ICMS - 90 – Outros
        /// </summary>
        [XmlElement(elementName: "ICMS90")]
        public ICMS90 ICMS90 { get; set; }

        /// <summary>
        /// Operação interestadual para consumidor final com 
        /// partilha do ICMS devido na operação entre a UF de 
        /// origem e a UF do destinatário ou a UF definida na
        /// legislação. (Ex. UF da concessionária de entrega do
        /// veículos) (v2.0)
        /// </summary>
        [XmlElement(elementName: "ICMSPart")]
        public ICMSPart ICMSPart { get; set; }

        /// <summary>
        /// Grupo de informação do ICMS ST devido para a UF de 
        /// destino, nas operações interestaduais de produtos que 
        /// tiveram retenção antecipada de ICMS por ST na UF do 
        /// remetente. Repasse via Substituto Tributário. (v2.0)
        /// </summary>
        [XmlElement(elementName: "ICMSST")]
        public ICMSST ICMSST { get; set; }

        /// <summary>
        /// Grupo de Tributação do ICMS pelo SIMPLES NACIONAL e
        /// CSOSN = 101 (v.2.0)
        /// </summary>
        [XmlElement(elementName: "ICMSSN101")]
        public ICMSSN101 ICMSSN101 { get; set; }

        /// <summary>
        /// Grupo de Tributação do ICMS pelo SIMPLES NACIONAL e 
        /// CSOSN = 101 (v.2.0)
        /// </summary>
        [XmlElement(elementName: "ICMSSN102")]
        public ICMSSN102 ICMSSN102 { get; set; }

        /// <summary>
        /// Grupo de Tributação do ICMS pelo SIMPLES NACIONAL e 
        /// CSOSN=201 (v.2.0)
        /// </summary>
        [XmlElement(elementName: "ICMSSN201")]
        public ICMSSN201 ICMSSN201 { get; set; }

        /// <summary>
        /// Grupo de Tributação do ICMS pelo SIMPLES NACIONAL e 
        /// CSOSN = 202 ou 203 (v.2.0)
        /// </summary>
        [XmlElement(elementName: "ICMSSN202")]
        public ICMSSN202 ICMSSN202 { get; set; }

        /// <summary>
        /// Grupo de Tributação do ICMS pelo SIMPLES NACIONAL e 
        /// CSOSN = 500 (v.2.0)
        /// </summary>
        [XmlElement(elementName: "ICMSSN500")]
        public ICMSSN500 ICMSSN500 { get; set; }

        /// <summary>
        /// Grupo de Tributação do ICMS pelo SIMPLES NACIONAL e 
        /// CSOSN = 900 (v.2.0)
        /// </summary>
        [XmlElement(elementName: "ICMSSN900")]
        public ICMSSN900 ICMSSN900 { get; set; }
    }
}
