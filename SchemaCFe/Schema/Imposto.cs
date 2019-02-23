using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class Imposto
    {
        /// <summary>
        /// Rateio do acréscimo sobre subtotal
        /// </summary>
        [XmlElement(ElementName = "vItem12741")]
        public string VItem12741 { get; set; }

        /// <summary>
        /// Grupo do ICMS da Operação própria e ST
        /// </summary>
        [XmlElement(ElementName = "ICMS")]
        public ICMS ICMS { get; set; }

        /// <summary>
        /// Grupo do PIS
        /// </summary>
        [XmlElement(ElementName = "PIS")]
        public PIS PIS { get; set; }

        /// <summary>
        /// Grupo do COFINS 
        /// </summary>
        [XmlElement(ElementName = "COFINS")]
        public COFINS COFINS { get; set; }

        /// <summary>
        /// Grupo do ISSQN
        /// </summary>
        [XmlElement(ElementName = "ISSQN")]
        public ISSQN ISSQN { get; set; }
    }
}