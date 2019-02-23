using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Med
    {
        /// <summary>
        /// Código de Produto da ANVISA, utilizar o número do registro ANVISA 
        /// farmacêuticas
        /// </summary>
        [XmlElement(elementName: "cProdANVISA")]
        public string CProdANVISA { get; set; }

        /// <summary>
        /// Preço máximo consumidor
        /// </summary>
        [XmlElement(elementName: "vPMC")]
        public string VPMC { get; set; }
    }
}
