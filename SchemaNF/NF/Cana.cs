using System.Collections.Generic;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Cana
    {
        /// <summary>
        /// Identificação da safra AAAA ou AAAA/AAAA
        /// </summary>
        [XmlElement(elementName: "safra")]
        public string Safra { get; set; }

        /// <summary>
        /// Mês e ano de referência MM/AAAA.
        /// </summary>
        [XmlElement(elementName: "ref")]
        public string Ref { get; set; }

        /// <summary>
        /// Grupo de Fornecimento diário de cana
        /// </summary>
        [XmlElement(elementName: "forDia")]
        public List<ForDia> ForDia { get; set; }

        /// <summary>
        /// Grupo de Deduções – Taxas e Contribuições
        /// </summary>
        [XmlElement(elementName: "deduc")]
        public List<Deduc> Deduc { get; set; }
    }
}
