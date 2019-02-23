using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class DetPag
    {
        /// <summary>
        /// Indicador da Forma de Pagamento 
        /// <para>
        /// 0= Pagamento à Vista
        /// 1= Pagamento à Prazo
        /// </para>
        /// </summary>
        [XmlElement(elementName: "indPag")]
        public string IndPag { get; set; }
        /// <summary>
        /// Forma de pagamento
        /// <para>
        /// 01- Dinheiro
        /// 02 -Cheque
        /// 03- Cartão de Crédito
        /// 04- Cartão de Débito
        /// 05- Crédito Loja
        /// 10- Vale Alimentação
        /// 11- Vale Refeição
        /// 12- Vale Presente
        /// 13- Vale Combustível
        /// 14=Duplicata Mercantil 
        /// 15=Boleto Bancário 
        /// 90= Sem pagamento 
        /// 99 – Outros
        /// </para>
        /// </summary>
        [XmlElement(elementName: "tPag")]
        public string TPag { get; set; }

        /// <summary>
        /// Valor do Pagamento
        /// </summary>
        [XmlElement(elementName: "vPag")]
        public string VPag { get; set; }

        /// <summary>
        /// Grupo de Cartões
        /// </summary>
        [XmlElement(elementName: "card")]
        public Card Card { get; set; }
    }
}
