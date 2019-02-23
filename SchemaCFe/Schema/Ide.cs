using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class Ide
    {
        /// <summary>
        /// Código da UF do emitente do Documento Fiscal
        /// </summary>
        [XmlElement(ElementName = "cUF")]
        public string CUF { get; set; }

        /// <summary>
        /// Código Numérico que compõe a Chave de Acesso
        /// </summary>
        [XmlElement(ElementName = "cNF")]
        public string CNF { get; set; }

        /// <summary>
        /// Código do Modelo do Documento Fiscal
        /// </summary>
        [XmlElement(ElementName = "mod")]
        public string Mod { get; set; }

        /// <summary>
        /// Número do Cupom Fiscal Eletronico
        /// </summary>
        [XmlElement(ElementName = "nserieSAT")]
        public string NserieSAT { get; set; }

        /// <summary>
        /// Data de emissão do Cupom Fiscal
        /// </summary>
        [XmlElement(ElementName = "dEmi")]
        public string DEmi { get; set; }

        /// <summary>
        /// Hora de emissão do Cupom Fiscal
        /// </summary>
        [XmlElement(ElementName = "hEmi")]
        public string HEmi { get; set; }

        /// <summary>
        /// Dígito Verificador da Chave de Acesso do CF-e
        /// </summary>
        [XmlElement(ElementName = "cDV")]
        public string CDV { get; set; }

        /// <summary>
        /// Identificação do Ambiente
        /// </summary>
        [XmlElement(ElementName = "tpAmb")]
        public string TpAmb { get; set; }

        /// <summary>
        /// CNPJ Software House
        /// </summary>
        [XmlElement(ElementName = "CNPJ")]
        public string CNPJ { get; set; }

        /// <summary>
        /// Assinatura do Aplicativo Comercial 
        /// </summary>
        [XmlElement(ElementName = "signAC")]
        public string SignAC { get; set; }

        /// <summary>
        /// Assinatura Digital para uso em QRCODE 
        /// </summary>
        [XmlElement(ElementName = "assinaturaQRCODE")]
        public string AssinaturaQRCODE { get; set; }

        /// <summary>
        /// Número do Caixa ao qual o SAT está conectado
        /// </summary>
        [XmlElement(ElementName = "NumeroCaixa")]
        public string NumeroCaixa { get; set; }
    }
}
