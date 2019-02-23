using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaNF.ProcNF
{
    public class InfProt
    {
        /// <summary>
        /// Identificador da TAG a ser assinada, somente
        /// precisa ser informado se a UF assinar a
        /// resposta.
        /// Em caso de assinatura da resposta pela
        /// SEFAZ preencher o campo com o Nro do
        /// Protocolo, precedido com o literal "ID"
        /// </summary>
        [XmlAttribute(attributeName: "Id")]
        public string Id { get; set; }

        /// <summary>
        /// Identificação do Ambiente: 
        /// <para>1 - Produção</para>
        /// <para>2 - Homologação</para>
        /// </summary>
        [XmlElement(elementName: "tpAmb")]
        public string TpAmb { get; set; }

        /// <summary>
        /// Versão do Aplicativo que recebeu o Lote. A versão deve ser iniciada 
        /// com a sigla da UF nos casos de WS próprio ou a sigla SCAN, SVAN ou 
        /// SVRS nos demais casos.
        /// </summary>
        [XmlElement(elementName: "verAplic")]
        public string VerAplic { get; set; }

        /// <summary>
        /// Chave de Acesso da NF-e (vide item 5.4)
        /// </summary>
        [XmlElement(elementName: "chNFe")]
        public string ChNFe { get; set; }

        /// <summary>
        /// Data e hora de processamento
        /// Formato = AAAA-MM-DDTHH:MM:SS
        /// Preenchido com data e hora da gravação da
        /// NF-e no Banco de Dados.
        /// Em caso de Rejeição, com data e hora do
        /// recebimento do Lote de NF-e enviado.
        /// </summary>
        [XmlElement(elementName: "dhRecbto")]
        public string DhRecbto { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "nProt")]
        public string NProt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "digVal")]
        public string DigVal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "cStat")]
        public string CStat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "xMotivo")]
        public string XMotivo { get; set; }
    }
}
