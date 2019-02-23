using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class DescAcrEntr
    {
        /// <summary>
        /// Valor de Entrada de Desconto sobre Subtotal
        /// </summary>
        [XmlElement(ElementName = "vDescSubtot")]
        public string VDescSubtot { get; set; }


        /// <summary>
        /// Valor de Entrada de Acréscimo sobre Subtotal
        /// </summary>
        [XmlElement(ElementName = "vAcresSubtot")]
        public string VAcresSubtot { get; set; }

    }
}