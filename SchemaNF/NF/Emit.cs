using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Emit
    {
        /// <summary>
        /// CNPJ do emitente
        /// </summary>
        [XmlElement(elementName: "CNPJ", Order =0)]
        public string CNPJ { get; set; }

        /// <summary>
        /// CPF do remetente
        /// </summary>
        [XmlElement(elementName: "CPF", Order = 1)]
        public string CPF { get; set; }

        /// <summary>
        /// Razão Social ou Nome do emitente
        /// </summary>
        [XmlElement(elementName: "xNome", Order = 2)]
        public string XNome { get; set; }

        /// <summary>
        /// Nome fantasia
        /// </summary>
        [XmlElement(elementName: "xFant", Order = 3)]
        public string XFant { get; set; }

        /// <summary>
        /// Grupo do Endereço do emitente
        /// </summary>
        [XmlElement(elementName: "enderEmit", Order = 4)]
        public Endereco EnderEmit { get; set; }

        /// <summary>
        /// Inscrição Estadual
        /// <para>
        ///     Obrigatória nos casos de emissão própria 
        ///     (procEmi = 0, ou 3). A IE deve ser informada 
        ///     apenas com algarismos para destinatários 
        ///     contribuintes do ICMS, sem caracteres de 
        ///     formatação (ponto, barra, hífen, etc.);
        ///     O literal “ISENTO” deve ser informado apenas 
        ///     para contribuintes do ICMS que são isentos de 
        ///     inscrição no cadastro de contribuintes do ICMS 
        ///     e estejam emitindo NF-e avulsa
        /// </para>
        /// </summary>
        [XmlElement(elementName: "IE", Order = 5)]
        public string IE { get; set; }

        /// <summary>
        /// IE do Substituto Tributário
        /// </summary>
        [XmlElement(elementName: "IEST", Order = 6)]
        public string IEST { get; set; }

        /// <summary>
        /// Inscrição Municipal
        /// <para>
        ///     Este campo deve ser informado, quando ocorrer a 
        ///     emissão de NF-e conjugada, com prestação de 
        ///     serviços sujeitos ao ISSQN e fornecimento de 
        ///     peças sujeitos ao ICMS.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "IM", Order = 7)]
        public string IM { get; set; }

        /// <summary>
        /// CNAE fiscal
        /// </summary>
        [XmlElement(elementName: "CNAE", Order = 8)]
        public string CNAE { get; set; }

        /// <summary>
        /// Código de Regime Tributário
        /// <para>1 – Simples Nacional;</para>
        /// <para>2 – Simples Nacional – excesso de sublimite de receita bruta</para>
        /// <para>3 – Regime Normal.</para>
        /// </summary>
        [XmlElement(elementName: "CRT", Order = 9)]
        public string CRT { get; set; }
    }
}
