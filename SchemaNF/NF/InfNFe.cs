using System.Collections.Generic;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class infNFe
    {
        /// <summary>
        /// Versão do leiaute (v2.0)
        /// </summary>
        [XmlAttribute(attributeName: "versao")]
        public string Versao { get; set; }

        /// <summary>
        /// informar a chave de acesso da 
        /// NF-e precedida do literal 'NFe',
        /// acrescentada a validação do formato (v2.0)
        /// </summary>
        [XmlAttribute(attributeName: "Id")]
        public string Id { get; set; }

        /// <summary>
        /// Grupo das informações de identificação da NF-e
        /// </summary>
        [XmlElement(elementName: "ide")]
        public Ide Ide { get; set; }

        /// <summary>
        /// Grupo de identificação do emitente da NF-e
        /// </summary>
        [XmlElement(elementName: "emit")]
        public Emit Emit { get; set; }

        /// <summary>
        /// Informações do fisco emitente, grupo de uso exclusivo do fisco.
        /// </summary>
        [XmlElement(elementName: "avulsa")]
        public Avulsa Avulsa { get; set; }

        /// <summary>
        /// Grupo de identificação do Destinatário da NF-e
        /// </summary>
        [XmlElement(elementName: "dest")]
        public Dest Dest { get; set; }

        /// <summary>
        /// Grupo de identificação do Local de retirada
        /// <para>
        ///     Informar apenas quando for diferente do endereço 
        ///     do remetente.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "retirada")]
        public EnderCom Retirada { get; set; }

        /// <summary>
        /// Grupo de identificação do Local de entrega
        /// <para>
        ///     Informar apenas quando for diferente do endereço 
        ///     do destinatário.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "entrega")]
        public EnderCom Entrega { get; set; }

        /// <summary>
        /// Pessoas autorizadas a acessar o XML da NF-e
        /// </summary>
        [XmlElement(elementName: "autXML")]
        public List<AutXML> AutXML { get; set; }

        /// <summary>
        /// Grupo do detalhamento de Produtos e Serviços da NF-e
        /// </summary>
        [XmlElement(elementName: "det")]
        public List<Det> Det { get; set; }
        /// <summary>
        /// Grupo Totais da NF-e
        /// </summary>
        [XmlElement(elementName: "total")]
        public Total Total { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "transp")]
        public Transp Transp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "cobr")]
        public Cobr Cobr { get; set; }

        /// <summary>
        /// Grupo de Informações de Pagamento 
        /// </summary>
        [XmlElement(elementName: "pag")]
        public Pag Pag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "infAdic")]
        public InfAdic InfAdic { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "exporta")]
        public Exporta Exporta { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "compra")]
        public Compra Compra { get; set; }

        /// <summary>
        /// Grupo de aquisição de cana
        /// </summary>
        [XmlElement(elementName: "cana")]
        public Cana Cana { get; set; }
    }
}
