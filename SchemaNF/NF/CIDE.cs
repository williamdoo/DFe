using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class CIDE
    {
        /// <summary>
        /// BC da CIDE em quantidade
        /// </summary>
        [XmlElement(elementName: "qBCprod")]
        public string QBCprod { get; set; }

        /// <summary>
        /// Valor da alíquota da CID
        /// </summary>
        [XmlElement(elementName: "vAliqProd")]
        public string VAliqProd { get; set; }

        /// <summary>
        /// Valor da CIDE
        /// </summary>
        [XmlElement(elementName: "vCIDE")]
        public string VCIDE { get; set; }
    }
}
