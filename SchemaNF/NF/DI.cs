using System.Collections.Generic;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class DI
    {
        /// <summary>
        /// Número do Documento de Importação DI/DSI/DA
        /// </summary>
        [XmlElement(elementName: "nDI")]
        public string NDI { get; set; }

        /// <summary>
        /// Data de Registro da DI/DSI/DA
        /// <para>Formato "AAAA-MM-DD"</para>
        /// </summary>
        [XmlElement(elementName: "dDI")]
        public string DDI { get; set; }

        /// <summary>
        /// Local de desembaraço
        /// </summary>
        [XmlElement(elementName: "xLocDesemb")]
        public string XLocDesemb { get; set; }

        /// <summary>
        /// Sigla da UF onde ocorreu o Desembaraço Aduaneiro
        /// </summary>
        [XmlElement(elementName: "UFDesemb")]
        public string UFDesemb { get; set; }

        /// <summary>
        /// Data do Desembaraço Aduaneiro
        /// <para>Formato "AAAA-MM-DD"</para>
        /// </summary>
        [XmlElement(elementName: "dDesemb")]
        public string DDesemb { get; set; }

        /// <summary>
        /// Código do exportador
        /// </summary>
        [XmlElement(elementName: "cExportador")]
        public string CExportador { get; set; }

        /// <summary>
        /// Adições
        /// </summary>
        [XmlElement(elementName: "adi")]
        public List<Adi> Adi { get; set; }
    }
}
