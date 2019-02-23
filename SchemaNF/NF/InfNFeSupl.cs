using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class InfNFeSupl
    {
        /// <summary>
        /// Texto com o QR-Code impresso no DANFE NFC-e
        /// </summary>
        [XmlElement(elementName: "qrCode")]
        public string QrCode { get; set; }

        /// <summary>
        /// Texto com a URL de consulta por chave de acesso a ser impressa no DANFE NFC-e
        /// </summary>
        [XmlElement(elementName: "urlChave")]
        public string UrlChave { get; set; }
    }
}
