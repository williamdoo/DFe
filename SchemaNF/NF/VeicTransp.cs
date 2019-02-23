using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class VeicTransp
    {
        /// <summary>
        /// Placa do Veículo
        /// </summary>
        [XmlElement(elementName: "placa")]
        public string Placa { get; set; }

        /// <summary>
        /// Sigla da UF
        /// </summary>
        [XmlElement(elementName: "UF")]
        public string UF { get; set; }

        /// <summary>
        /// Registro Nacional de Transportador de Carga (ANTT)
        /// </summary>
        [XmlElement(elementName: "RNTC")]
        public string RNTC { get; set; }
    }
}
