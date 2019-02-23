using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class NFref
    {
        /// <summary>
        /// Chave de acesso da NF-e referenciada
        /// <para>
        ///     Utilizar esta TAG para referenciar uma Nota 
        ///     Fiscal Eletrônica emitida anteriormente, 
        ///     vinculada a NF-e atual.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "refNFe")]
        public string RefNFe { get; set; }

        /// <summary>
        /// Grupo de informações da NF referenciada
        /// </summary>
        [XmlElement(elementName: "refNF")]
        public RefNF RefNF { get; set; }

        /// <summary>
        /// Grupo de informações da NF de produtor rural referenciada
        /// </summary>
        [XmlElement(elementName: "refNFP")]
        public RefNFP RefNFP { get; set; }

        /// <summary>
        /// Chave de acesso do CT-e referenciada
        /// </summary>
        [XmlElement(elementName: "refCTe")]
        public string RefCTe { get; set; }

        /// <summary>
        /// Informações do Cupom Fiscal referenciado
        /// </summary>
        [XmlElement(elementName: "refECF")]
        public RefECF RefECF { get; set; }
    }
}
