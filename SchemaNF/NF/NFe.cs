using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [XmlRoot("NFe", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public class NFe
    {
        /// <summary>
        /// Grupo que contém as informações da NF-e
        /// </summary>
        [XmlElement(elementName: "infNFe")]
        public infNFe InfNFe { get; set; }

        /// <summary>
        /// Informações suplementares da Nota Fiscal
        /// </summary>
        [XmlElement(elementName: "infNFeSupl")]
        public InfNFeSupl InfNFeSupl { get; set; } 
    }
}
