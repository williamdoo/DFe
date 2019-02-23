using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Rastro
    {
        /// <summary>
        /// Número do Lote do produto 
        /// </summary>
        [XmlElement(elementName: "nLote")]
        public string NLote { get; set; }

        /// <summary>
        /// Quantidade de produto no Lote 
        /// </summary>
        [XmlElement(elementName: "qLote")]
        public string QLote { get; set; }

        /// <summary>
        /// Data de fabricação/ Produção
        /// <para>
        /// Formato: "AAAA-MM-DD"
        /// </para>
        /// </summary>
        [XmlElement(elementName: "dFab")]
        public string DFab { get; set; }

        /// <summary>
        /// Data de validade
        /// <para>
        /// Formato: "AAAA-MM-DD" Informar o último dia do mês caso a validade não especifique o dia
        /// </para>
        /// </summary>
        [XmlElement(elementName: "dVal")]
        public string DVal { get; set; }

        /// <summary>
        /// Código de Agregação
        /// </summary>
        [XmlElement(elementName: "cAgreg")]
        public string CAgreg { get; set; }
    }
}
