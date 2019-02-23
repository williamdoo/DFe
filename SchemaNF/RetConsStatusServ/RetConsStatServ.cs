using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaNF.RetConsStatusServ
{
    [Serializable()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [XmlRoot("retConsStatServ", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public class RetConsStatServ
    {
        /// <summary>
        /// Versão do leiaute
        /// </summary>
        [XmlAttribute(AttributeName = "versao")]
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
        /// Código do status da resposta.
        /// </summary>
        [XmlElement(ElementName = "cStat")]
        public string CStat { get; set; }

        /// <summary>
        /// Descrição literal do status da resposta
        /// </summary>
        [XmlElement(ElementName = "xMotivo")]
        public string XMotivo { get; set; }

        /// <summary>
        /// Código da UF que atendeu a solicitação.
        /// </summary>
        [XmlElement(ElementName = "cUF")]
        public string CUF { get; set; }

        /// <summary>
        /// Data e hora de recebimento
        /// Formato = AAAA-MM-DDTHH:MM:SS
        /// Preenchido com data e hora do recebimento do Pedido.
        /// </summary>
        [XmlElement(ElementName = "dhRecebto")]
        public string DhRecebto { get; set; }

        /// <summary>
        /// Tempo médio de resposta do serviço (em
        /// segundos) dos últimos 5 minutos (item 5.7).
        /// </summary>
        [XmlElement(ElementName = "tMed")]
        public string TMed { get; set; }

        /// <summary>
        /// Preencher com data e hora previstas para o
        /// retorno do Web Service, no formato AAA-MMDDTHH:MM:SS
        /// </summary>
        [XmlElement(ElementName = "dhRetorno")]
        public string DhRetorno { get; set; }

        /// <summary>
        /// Informações adicionais para o Contribuinte
        /// </summary>
        [XmlElement(ElementName = "xObs")]
        public string XObs { get; set; }
    }
}
