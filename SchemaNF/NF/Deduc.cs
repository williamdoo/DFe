using System.Collections.Generic;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Deduc
    {
        /// <summary>
        /// Descrição da Dedução
        /// </summary>
        [XmlElement(elementName: "xDed")]
        public List<ForDia> XDed { get; set; }

        /// <summary>
        /// Valor da Dedução
        /// </summary>
        [XmlElement(elementName: "vDed")]
        public List<ForDia> VDed { get; set; }

        /// <summary>
        /// Valor dos Fornecimentos
        /// </summary>
        [XmlElement(elementName: "vFor")]
        public List<ForDia> VFor { get; set; }

        /// <summary>
        /// Valor Total da Dedução
        /// </summary>
        [XmlElement(elementName: "vTotDed")]
        public List<ForDia> VTotDed { get; set; }

        /// <summary>
        /// Valor Líquido dos Fornecimentos
        /// </summary>
        [XmlElement(elementName: "vLiqFor")]
        public List<ForDia> VLiqFor { get; set; }
    }
}
