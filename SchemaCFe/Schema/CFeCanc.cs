using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    /// <summary>
    /// TAG raiz do CF-e Cancelamento
    /// </summary>
    [XmlRoot("CFeCanc")]
    public class CFeCanc
    {
        /// <summary>
        /// Grupo das informações do CF-e
        /// </summary>
        [XmlElement(ElementName = "infCFe")]
        public InfCFe InfCFe { get; set; }
    }
}
