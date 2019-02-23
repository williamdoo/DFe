using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    /// <summary>
    /// Grupo das informações do CF-e
    /// </summary>
    public class InfCFe
    {
        /// <summary>
        /// Versão do leiaute do arquivo de dados do AC
        /// </summary>
        [XmlAttribute(AttributeName = "versaoDadosEnt")]
        public string VersaoDadosEnt { get; set; }

        /// <summary>
        /// Versão do leiaute do CF-e
        /// </summary>
        [XmlElement(ElementName = "Versao")]
        public string Versao { get; set; }

        
        /// <summary>
        /// Versão do leiaute do arquivo de dados do AC
        /// </summary>
        [XmlElement(ElementName = "versaoSB")]
        public string VersaoSB { get; set; }

        /// <summary>
        /// Identificador da TAG a ser assinada
        /// </summary>
        [XmlElement(ElementName = "Id")]
        public string Id { get; set; }

        /// <summary>
        /// Chave de acesso do CF-e a ser cancelado 
        /// </summary>
        [XmlElement(ElementName = "chCanc")]
        public string ChCanc { get; set; }

        /// <summary>
        /// Data de emissão do CF-e a ser cancelado
        /// </summary>
        [XmlElement(ElementName = "dEmi")]
        public string DEmi { get; set; }

        /// <summary>
        /// Hora de emissão do CF-e a ser cancelado
        /// </summary>
        [XmlElement(ElementName = "hEmi")]
        public string HEmi { get; set; }

        /// <summary>
        /// Grupo das informações de identificação do CF-e
        /// </summary>
        [XmlElement(ElementName = "ide")]
        public Ide Ide { get; set; }

        /// <summary>
        /// Grupo de identificação do emitente do CF-e
        /// </summary>
        [XmlElement(ElementName = "emit")]
        public Emit Emit { get; set; }

        /// <summary>
        /// Grupo de identificação do Destinatário do CF-e
        /// </summary>
        [XmlElement(ElementName = "dest")]
        public Dest Dest { get; set; }

        /// <summary>
        /// Grupo de identificação do Local de entrega
        /// </summary>
        [XmlElement(ElementName = "entrega")]
        public Entrega Entrega { get; set; }

        /// <summary>
        /// Grupo do detalhamento de Produtos e Serviços do CF-e 
        /// </summary>
        [XmlElement(ElementName = "det")]
        public List<Det> Det { get; set; }

        /// <summary>
        /// Grupo do detalhamento de Produtos e Serviços do CF-e 
        /// </summary>
        [XmlElement(ElementName = "total")]
        public Total Total { get; set; }

        /// <summary>
        /// Grupo de informações sobre Pagamento do CFe 
        /// </summary>
        [XmlElement(ElementName = "pgto")]
        public Pgto Pgto { get; set; }

        /// <summary>
        /// Grupo de informações sobre Pagamento do CFe 
        /// </summary>
        [XmlElement(ElementName = "infAdic")]
        public InfAdic InfAdic { get; set; }
    }
}
