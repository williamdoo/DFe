using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace SchemaNF.ConsReciboNFe
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [XmlRoot("consReciNFe", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public class ConsReciNFe
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
        /// Número do Recibo
        /// Número gerado pelo Portal da Secretaria de
        /// Fazenda Estadual
        /// </summary>
        [XmlElement(ElementName = "nRec")]
        public string NRec { get; set; }
    }
}
