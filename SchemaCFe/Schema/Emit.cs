using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class Emit
    {
        /// <summary>
        /// CNPJ do emitente
        /// </summary>
        [XmlElement(ElementName = "CNPJ")]
        public string CNPJ { get; set; }

        /// <summary>
        /// Razão Social do emitente
        /// </summary>
        [XmlElement(ElementName = "xNome")]
        public string XNome { get; set; }

        /// <summary>
        /// Nome fantasia
        /// </summary>
        [XmlElement(ElementName = "xFant")]
        public string XFant { get; set; }

        /// <summary>
        /// Grupo do Endereço do emitent
        /// </summary>
        [XmlElement(ElementName = "enderEmit")]
        public EnderEmit EnderEmit { get; set; }

        /// <summary>
        /// Inscrição Estadual 
        /// </summary>
        [XmlElement(ElementName = "IE")]
        public string IE { get; set; }

        /// <summary>
        /// Inscrição Municipal
        /// </summary>
        [XmlElement(ElementName = "IM")]
        public string IM { get; set; }

        /// <summary>
        /// Código de Regime Tributário
        /// </summary>
        [XmlElement(ElementName = "cRegTrib")]
        public string CRegTrib { get; set; }

        /// <summary>
        /// Regime Especial de Tributação do ISSQN
        /// </summary>
        [XmlElement(ElementName = "cRegTribISSQN")]
        public string CRegTribISSQN { get; set; }

        /// <summary>
        /// Indicador de rateio do Desconto sobre subtotal entre itens sujeitos à tributação pelo ISSQN
        /// </summary>
        [XmlElement(ElementName = "indRatISSQN")]
        public string IndRatISSQN { get; set; }
    }
}
