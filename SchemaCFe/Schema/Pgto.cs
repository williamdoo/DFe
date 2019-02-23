using System.Collections.Generic;
using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class Pgto
    {
        /// <summary>
        /// Grupo de informações dos Meios de Pagamento empregados na quitação do CF-e
        /// </summary>
        [XmlElement(ElementName = "MP")]
        public List<MP> MP { get; set; }
    }
}