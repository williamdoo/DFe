using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Card
    {
        /// <summary>
        /// Tipo de Integração para pagamento
        /// 
        /// <para>1=Pagamento integrado com o sistema de automação da empresa (Ex.: equipamento TEF, Comércio Eletrônico)</para>
        /// <para>2= Pagamento não integrado com o sistema de automação da empresa (Ex.: equipamento POS)</para>
        /// </summary>
        [XmlElement(elementName: "tpIntegra")]
        public string TpIntegra { get; set; }

        /// <summary>
        /// CNPJ da Credenciadora de cartão de crédito e/ou débito
        /// 
        /// <para>Informar o CNPJ da Credenciadora de cartão de crédito / débito</para>
        /// </summary>
        [XmlElement(elementName: "CNPJ")]
        public string CNPJ { get; set; }

        /// <summary>
        /// Bandeira da operadora de cartão de crédito e/ou débito
        ///
        /// <para>
        /// 01- Visa
        /// 02- Mastercard
        /// 03- American Express
        /// 04- Sorocred
        /// 99- Outros
        /// </para>
        /// </summary>
        [XmlElement(elementName: "tBand")]
        public string TBand { get; set; }

        /// <summary>
        /// Número de autorização da operação cartão de crédito e/ou débito
        /// <para>
        /// Identifica o número da autorização da transação da operação com
        /// cartão de crédito e/ou débito
        /// </para>
        /// </summary>
        [XmlElement(elementName: "cAut")]
        public string CAut { get; set; }
    }
}
