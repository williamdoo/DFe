using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaNF.ProcNF
{
    public class ProtNFe
    {
        /// <summary>
        /// Versão do leiaute das informações de Protocolo.
        /// </summary>
        [XmlAttribute(attributeName: "versao")]
        public string Versao { get; set; }

        /// <summary>
        /// Informações do Protocolo de resposta.
        /// TAG a ser assinada
        /// </summary>
        [XmlElement(elementName: "infProt")]
        public InfProt InfProt { get; set; }
    }
}
