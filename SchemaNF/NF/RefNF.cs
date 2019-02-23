using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class RefNF
    {
        /// <summary>
        /// Código da UF do emitente do Documento Fiscal
        /// <para>
        ///     Utilizar a Tabela do IBGE (Anexo VII - 
        ///     Tabela de UF, Município e País)
        /// </para>
        /// </summary>
        [XmlElement(elementName: "cUF")]
        public string CUF { get; set; }

        /// <summary>
        /// Ano e Mês de emissão da NFe
        /// <para>
        ///     AAMM da emissão da NF
        /// </para>
        /// </summary>
        [XmlElement(elementName: "AAMM")]
        public string AAMM { get; set; }

        /// <summary>
        /// CNPJ do emitente
        /// </summary>
        [XmlElement(elementName: "CNPJ")]
        public string CNPJ { get; set; }

        /// <summary>
        /// Modelo do Documento Fiscal
        /// </summary>
        [XmlElement(elementName: "mod")]
        public string Mod { get; set; }

        /// <summary>
        /// Série do Documento Fiscal (informar zero se inexistente).
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
