using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaNF.RetEnvNF
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [XmlRoot("retEnviNFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class RetEnviNFe
    {
        /// <summary>
        /// Versão do leiaute
        /// </summary>
        [XmlAttribute(AttributeName= "versao")]
        public string Versao { get; set; }

        /// <summary>
        /// Identificação do Ambiente: 
        /// <para>1 - Produção</para>
        /// <para>2 - Homologação</para>
        /// </summary>
        [XmlElement(ElementName = "tpAmb")]
        public string TpAmb { get; set; }

        /// <summary>
        /// Versão do Aplicativo que recebeu o Lote. A versão deve ser iniciada 
        /// com a sigla da UF nos casos de WS próprio ou a sigla SCAN, SVAN ou 
        /// SVRS nos demais casos.
        /// </summary>
        [XmlElement(ElementName = "verAplic")]
        public string VerAplic { get; set; }

        /// <summary>
        /// Código do status da resposta
        /// </summary>
        [XmlElement (ElementName = "cStat")]
        public string CStat { get; set; }

        /// <summary>
        /// Descrição literal do status da resposta
        /// </summary>
        [XmlElement (ElementName = "xMotivo")]
        public string XMotivo { get; set; }

        /// <summary>
        /// Código da UF que atendeu a solicitação.
        /// </summary>
        [XmlElement(ElementName = "cUF")]
        public string CUF { get; set; }

        ///// <summary>
        ///// Data e Hora do Recebimento 
        ///// Formato = AAAA-MM-DDTHH:MM:SS
        ///// Preenchido com data e hora do recebimento do lote.
        ///// </summary>
        //[XmlElement]
        //public string dhRecebto { get; set; }

        /// <summary>
        /// Data e Hora do Recebimento 
        /// Formato = AAAA-MM-DDTHH:MM:SS
        /// Preenchido com data e hora do recebimento do lote.
        /// </summary>
        [XmlElement(ElementName = "dhRecbto")]
        public string DhRecbto { get; set; }


        /// <summary>
        /// Dados do Recibo do Lote (Só é gerado se o Lote for aceito)
        /// </summary>
        [XmlElement(ElementName = "infRec")]
        public InfRec InfRec { get; set; }
    }
}
