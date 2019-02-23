using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class RefNFP
    {
        /// <summary>
        /// Código da UF do emitente do Documento Fiscal
        /// <para>
        ///     Utilizar a Tabela do IBGE (Anexo VII - 
        ///     Tabela de UF, Município e País) (v2.0)
        /// </para>
        /// </summary>
        [XmlElement(elementName: "cUF")]
        public string CUF { get; set; }

        /// <summary>
        /// Ano e Mês de emissão da NFe (AAMM)
        /// </summary>
        [XmlElement(elementName: "AAMM")]
        public string AAMM { get; set; }

        /// <summary>
        /// CNPJ do emitente
        /// </summary>
        [XmlElement(elementName: "CNPJ")]
        public string CNPJ { get; set; }

        /// <summary>
        /// CPF do emitente
        /// </summary>
        [XmlElement(elementName: "")]
        public string CPF { get; set; }

        /// <summary>
        /// IE do emitente
        /// </summary>
        [XmlElement(elementName: "IE")]
        public string IE { get; set; }

        /// <summary>
        /// Modelo do Documento Fiscal
        /// <para>01- NF avulsa</para>
        /// <para>04 – NF de Produtor</para>
        /// </summary>
        [XmlElement(elementName: "mod")]
        public string Mod { get; set; }

        /// <summary>
        /// Série do Documento Fiscal (informar zero se inexistente)
        /// </summary>
        [XmlElement(elementName: "serie")]
        public string Serie { get; set; }

        /// <summary>
        /// Número do Documento Fiscal
        /// </summary>
        [XmlElement(elementName: "nNF")]
        public string NNF { get; set; }
    }
}
