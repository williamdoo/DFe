using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class InfAdic
    {
        /// <summary>
        /// Informações Complementares de interesse do Contribuinte
        /// </summary>
        [XmlElement(ElementName = "infCpl")]
        public string InfCpl { get; set; }

        /// <summary>
        /// Grupo do campo de uso livre do Fisco
        /// </summary>
        [XmlElement(ElementName = "obsFisco")]
        public ObsFisco ObsFisco { get; set; }
    }
}