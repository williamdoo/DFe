using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class EnderCom
    {
        /// <summary>
        /// CNPJ
        /// </summary>
        [XmlElement(elementName: "CNPJ")]
        public string CNPJ { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        [XmlElement(elementName: "CPF")]
        public string CPF { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        [XmlElement(elementName: "xLgr")]
        public string XLgr { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        [XmlElement(elementName: "nro")]
        public string Nro { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        [XmlElement(elementName: "xCpl")]
        public string XCpl { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        [XmlElement(elementName: "xBairro")]
        public string XBairro { get; set; }

        /// <summary>
        /// Cósigo do Município
        /// </summary>
        [XmlElement(elementName: "cMun")]
        public string CMun { get; set; }

        /// <summary>
        /// Nome do Município
        /// </summary>
        [XmlElement(elementName: "xMun")]
        public string XMun { get; set; }

        /// <summary>
        /// Sigla da UF
        /// </summary>
        [XmlElement(elementName: "UF")]
        public string UF { get; set; }
    }
}
