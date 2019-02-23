using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SchemaNF.NF;

namespace SchemaNF.Lote
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [XmlRoot("enviNFe", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public class EnviNFe
    {
        /// <summary>
        /// Versão do leiaute
        /// </summary>
        [XmlAttribute(AttributeName = "versao")]
        public string Versao { get; set; }

        /// <summary>
        /// Identificador de controle do envio do lote.
        /// Número seqüencial auto-incremental, de
        /// controle correspondente ao identificador único
        /// do lote enviado. A responsabilidade de gerar e
        /// controlar esse número é exclusiva do
        /// contribuinte.
        /// </summary>
        [XmlElement(ElementName = "idLote")]
        public string IdLote { get; set; }

        /// <summary>
        /// 0=Não.
        /// 1=Empresa solicita processamento síncrono do Lote de NF-e (sem a geração de Recibo para consulta futura);
        /// Nota: O processamento síncrono do Lote corresponde a entrega da resposta do 
        /// processamento das NF-e do Lote, sem a geração de um Recibo de Lote para consulta
        /// futura. A resposta de forma síncrona pela SEFAZ Autorizadora só ocorrerá se:
        /// - a empresa solicitar e constar unicamente uma NF-e no Lote; 
        /// - a SEFAZ Autorizadora implementar o processamento síncrono para a resposta do Lote de
        /// NF-e.
        /// </summary>
        [XmlElement(ElementName = "indSinc")]
        public string IndSinc { get; set; }

        /// <summary>
        /// Conjunto de NF-e transmitidas (máximo de 50
        /// NF-e), seguindo definição do Anexo I - Leiaute da NF-e.
        /// </summary>
        [XmlElement(ElementName = "NFe")]
        public List<NFe> NFe { get; set; }
    }
}
