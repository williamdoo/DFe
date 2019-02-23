using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SchemaNF.NF;

namespace SchemaNF.ProcNF
{
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe", ElementName = "nfeProc")]
    public class ProcNFe
    {
        /// <summary>
        /// Versão do laioute
        /// </summary>
        [XmlAttribute(attributeName: "versao")]
        public string Versao { get; set; }

        /// <summary>
        /// Dados da NF-e, inclusive com os dados da assinatura (Anexo I)
        /// </summary>
        [XmlElement(elementName: "NFe")]
        public NFe NFe { get; set; }

        /// <summary>
        /// Dados do Protocolo de Autorização de Uso (item 4.2.2)
        /// </summary>
        [XmlElement(elementName: "protNFe")]
        public ProtNFe ProtNFe { get; set; }
    }
}
