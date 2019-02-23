using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class MP
    {
        /// <summary>
        /// Código do Meio de Pagamento empregado para quitação do CF-e
        /// </summary>
        [XmlElement(ElementName = "cMP")]
        public string CMP { get; set; }


        /// <summary>
        /// Valor do Meio de Pagamento empregado para quitação do CF-e
        /// </summary>
        [XmlElement(ElementName = "vMP")]
        public string VMP { get; set; }


        /// <summary>
        /// Credenciadora de cartão de débito ou crédito
        /// </summary>
        [XmlElement(ElementName = "cAdmC")]
        public string CAdmC { get; set; }


        /// <summary>
        /// Valor do troco 
        /// </summary>
        [XmlElement(ElementName = "vTroco")]
        public string VTroco { get; set; }

    }
}