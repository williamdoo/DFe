using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class EnderEmit
    {
        /// <summary>
        /// Logradouro
        /// </summary>
        [XmlElement(ElementName = "xLgr")]
        public string XLgr { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        [XmlElement(ElementName = "nro")]
        public string Nro { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        [XmlElement(ElementName = "xCpl")]
        public string XCpl { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        [XmlElement(ElementName = "xBairro")]
        public string XBairro { get; set; }

        /// <summary>
        /// Nome do município
        /// </summary>
        [XmlElement(ElementName = "xMun")]
        public string XMun { get; set; }

        /// <summary>
        /// Código do CEP 
        /// </summary>
        [XmlElement(ElementName = "CEP")]
        public string CEP { get; set; }

    }
}
