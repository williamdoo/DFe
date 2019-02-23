using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Adi
    {
        /// <summary>
        /// Numero da adição
        /// </summary>
        [XmlElement(elementName: "nAdicao")]
        public string NAdicao { get; set; }

        /// <summary>
        /// Numero seqüencial do item dentro da adição
        /// </summary>
        [XmlElement(elementName: "nSeqAdic")]
        public string NSeqAdic { get; set; }

        /// <summary>
        /// Código do fabricante estrangeiro
        /// </summary>
        [XmlElement(elementName: "cFabricante")]
        public string CFabricante { get; set; }

        /// <summary>
        /// Valor do desconto do item da DI – adição
        /// </summary>
        [XmlElement(elementName: "vDescDI")]
        public string VDescDI { get; set; }
    }
}
