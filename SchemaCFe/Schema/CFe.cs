using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    /// <summary>
    /// TAG raiz do CF-e
    /// </summary>
    [Serializable()]
    [XmlRoot("CFe")]
    public class CFe
    {
        /// <summary>
        /// Grupo das informações do CF-e
        /// </summary>
        [XmlElement(ElementName = "infCFe")]
        public InfCFe InfCFe { get; set; }


        /// <summary>
        /// Assinatura XML do CF-e Segundo o Padrão XML Digital Signature
        /// </summary>
        [XmlElement(ElementName = "Signature")]
        public string Signature { get; set; }
    }
}
