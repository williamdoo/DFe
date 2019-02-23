using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class ForDia
    {
        /// <summary>
        /// Dia
        /// </summary>
        [XmlElement(elementName: "dia")]
        public string Dia { get; set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        [XmlElement(elementName: "qtde")]
        public string Qtde { get; set; }

        /// <summary>
        /// Quantidade Total do Mês
        /// </summary>
        [XmlElement(elementName: "qTotMes")]
        public string QTotMes { get; set; }

        /// <summary>
        /// Quantidade Total Anterior
        /// </summary>
        [XmlElement(elementName: "qTotAnt")]
        public string QTotAnt { get; set; }

        /// <summary>
        /// Quantidade Total Gera
        /// </summary>
        [XmlElement(elementName: "qTotGer")]
        public string QTotGer { get; set; }
    }
}
