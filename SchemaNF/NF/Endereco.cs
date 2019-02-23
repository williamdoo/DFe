using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Endereco
    {
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
        /// Código do Município
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

        /// <summary>
        /// Código do CEP
        /// </summary>
        [XmlElement(elementName: "CEP")]
        public string CEP { get; set; }

        /// <summary>
        /// Código do País 
        /// <para>1058 - Brasi</para>
        /// </summary>
        [XmlElement(elementName: "cPais")]
        public string CPais { get; set; }

        /// <summary>
        /// Nome do País
        /// </summary>
        [XmlElement(elementName: "xPais")]
        public string XPais { get; set; }

        /// <summary>
        /// Telefone
        /// <para>
        ///     Preencher com o Código DDD + número do 
        ///     telefone. Nas operações com exterior é
        ///     permitido informar o código do país + 
        ///     código da localidade + número do telefone (v.2.0)
        /// </para>
        /// </summary>
        [XmlElement(elementName: "fone")]
        public string Fone { get; set; }
    }
}
