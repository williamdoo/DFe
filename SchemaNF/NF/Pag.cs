using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Pag
    {
        /// <summary>
        /// Grupo Detalhamento do Pagamento
        /// </summary>
        [XmlElement(elementName: "detPag")]
        public List<DetPag> DetPag { get; set; }

        /// <summary>
        /// Valor do troco
        /// </summary>
        [XmlElement(elementName: "vTroco")]
        public string VTroco { get; set; }
    }
}
