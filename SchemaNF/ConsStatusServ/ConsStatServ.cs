using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaNF.ConsStatusServ
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("consStatServ", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class ConsStatServ
    {
        /// <summary>
        /// Versão do leiaute
        /// </summary>
        [XmlAttribute(AttributeName = "versao")]
        public string Versao { get; set; }

        /// <summary>
        /// Identificação do Ambiente:
        /// <para>1 – Produção</para>
        /// <para>2 – Homologação</para>
        /// </summary>
        [XmlElement(ElementName = "tpAmb")]
        public string TpAmb { get; set; }

        /// <summary>
        /// Código da UF consultada
        /// </summary>
        [XmlElement(ElementName = "cUF")]
        public string CUF { get; set; }

        /// <summary>
        /// Serviço solicitado 'STATUS'
        /// </summary>
        [XmlElement(ElementName = "xServ")]
        public string XServ { get; set; }
    }
}
