using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Dest
    {
        /// <summary>
        /// CNPJ do destinatário
        /// <para>
        /// Opcional, informar os zeros não significativos. Não informar esta tag se
        /// operação com Exterior. Nota: Campo não aceita o valor Nulo.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "CNPJ")]
        public string CNPJ { get; set; }

        /// <summary>
        /// CPF do destinatário
        /// 
        /// <para>
        /// Opcional, informar os zeros não significativos.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "CPF")]
        public string CPF { get; set; }

        /// <summary>
        /// Identificação do destinatário no caso
        /// de comprador estrangeiro
        /// <para>
        /// Opcional, Número do passaporte ou
        /// outro documento legal para identificar
        /// pessoa estrangeira. Informar esta tag no
        /// caso de operação com o exterior.
        /// Nota: Campo aceita valor Nulo.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "idEstrangeiro")]
        public string IdEstrangeiro { get; set; }

        /// <summary>
        /// Razão Social ou nome do destinatário
        /// </summary>
        [XmlElement(elementName: "xNome")]
        public string XNome { get; set; }

        /// <summary>
        /// Grupo de endereço do Destinatário da NF-e
        /// </summary>
        [XmlElement(elementName: "enderDest")]
        public Endereco EnderDest { get; set; }

        /// <summary>
        /// Indicador da IE do Destinatário
        /// <para>
        /// 1=Contribuinte ICMS (informar a IE do destinatário);
        /// 2=Contribuinte isento de Inscrição no cadastro de
        /// Contribuintes do ICMS;
        /// 9=Não Contribuinte, que pode ou não possuir Inscrição
        /// </para>
        /// <para>
        /// Estadual no Cadastro de Contribuintes do ICMS.
        /// Nota 1: No caso de NFC-e informar indIEDest=9 e não
        /// informar a tag IE do destinatário;
        /// Nota 2: No caso de operação com o Exterior informar
        /// indIEDest=9 e não informar a tag IE do destinatário;
        /// Nota 3: No caso de Contribuinte Isento de Inscrição
        /// (indIEDest=2), não informar a tag IE do destinatário.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "indIEDest")]
        public string IndIEDest { get; set; }

        /// <summary>
        /// Inscrição Estadual
        /// <para>
        ///     Informar a IE quando o destinatário for 
        ///     contribuinte do ICMS.
        /// </para>
        /// <para>
        ///     Informar ISENTO quando o destinatário for 
        ///     contribuinte do ICMS, mas não estiver obrigado
        ///     à inscrição no cadastro de contribuintes do ICMS.
        /// </para>
        /// <para>
        ///     Não informar o conteúdo da TAG se o destinatário 
        ///     não for contribuinte do ICMS.
        /// </para>
        /// <para>
        ///     Esta tag aceita apenas:
        /// </para>
        /// <para>
        ///     . ausência de conteúdo (<IE></IE> ou <IE/>) para
        ///     destinatários não contribuintes do ICMS
        /// </para>
        /// <para>
        ///     . algarismos para destinatários
        ///     contribuintes do ICMS, sem caracteres de formatação
        ///     (ponto, barra, hífen, etc.)
        /// </para>
        /// <para>
        ///     . literal “ISENTO” para destinatários contribuintes 
        ///     do ICMS que são isentos de inscrição no cadastro de
        ///     contribuintes do ICMS
        /// </para>
        /// <para>
        ///     No caso de informação da IE, informar somente os algarismos, sem os
        ///     caracteres de formatação (ponto, barra, hífen, etc.).
        ///     Nota: Não informar esta tag no caso da NFC-e.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "IE")]
        public string IE { get; set; }

        /// <summary>
        /// Inscrição na SUFRAMA
        /// <para>
        ///     Obrigatório, nas operações que se beneficiam de 
        ///     incentivos fiscais existentes nas áreas sob
        ///     controle da SUFRAMA. A omissão da Inscrição
        ///     SUFRAMA impede o processamento da operação
        ///     pelo Sistema de Mercadoria Nacional da SUFRAMA e 
        ///     a liberação da Declaração de Ingresso, prejudicando a
        ///     comprovação do ingresso/internamento da mercadoria nas 
        ///     áreas sob controle da SUFRAMA. (v2.0)
        /// </para>
        /// </summary>
        [XmlElement(elementName: "ISUF")]
        public string ISUF { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [XmlElement(elementName: "email")]
        public string Email { get; set; }
    }
}
