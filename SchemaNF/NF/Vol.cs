using System.Collections.Generic;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Vol
    {
        /// <summary>
        /// Quantidade de volumes transportados
        /// </summary>
        [XmlElement(elementName: "qVol")]
        public string QVol { get; set; }

        /// <summary>
        /// Espécie dos volumes transportados
        /// </summary>
        [XmlElement(elementName: "esp")]
        public string Esp { get; set; }

        /// <summary>
        /// Marca dos volumes transportados
        /// </summary>
        [XmlElement(elementName: "marca")]
        public string Marca { get; set; }

        /// <summary>
        /// Numeração dos volumes transportados
        /// </summary>
        [XmlElement(elementName: "nVol")]
        public string NVol { get; set; }

        /// <summary>
        /// Peso Líquido (em kg)
        /// </summary>
        [XmlElement(elementName: "pesoL")]
        public string PesoL { get; set; }

        /// <summary>
        /// Peso Bruto (em kg)
        /// </summary>
        [XmlElement(elementName: "pesoB")]
        public string PesoB { get; set; }

        /// <summary>
        /// Grupo de Lacres
        /// </summary>
        [XmlElement(elementName: "lacres")]
        public List<Lacres> Lacres { get; set; }
    }
}
