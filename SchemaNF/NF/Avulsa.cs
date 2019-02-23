using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Avulsa
    {
        /// <summary>
        /// CNPJ do órgão emitente
        /// </summary>
        [XmlElement(elementName: "CPNJ")]
        public string CPNJ { get; set; }

        /// <summary>
        /// Órgão emitente
        /// </summary>
        [XmlElement(elementName: "xOrgao")]
        public string XOrgao { get; set; }

        /// <summary>
        /// Matrícula do agente
        /// </summary>
        [XmlElement(elementName: "matr")]
        public string Matr { get; set; }

        /// <summary>
        /// Nome do agente
        /// </summary>
        [XmlElement(elementName: "xAgente")]
        public string XAgente { get; set; }

        /// <summary>
        /// Telefone
        /// <para>Preencher com Código DDD + número do telefone (v.2.0)</para>
        /// </summary>
        [XmlElement(elementName: "fone")]
        public string Fone { get; set; }

        /// <summary>
        /// Sigla da UF
        /// </summary>
        [XmlElement(elementName: "UF")]
        public string UF { get; set; }

        /// <summary>
        /// Número do Documento de Arrecadação de Receita
        /// </summary>
        [XmlElement(elementName: "nDAR")]
        public string NDAR { get; set; }

        /// <summary>
        /// Data de emissão do Documento de Arrecadação
        /// <para>Formato "AAAA-MM-DD"</para>
        /// </summary>
        [XmlElement(elementName: "dEmi")]
        public string DEmi { get; set; }

        /// <summary>
        /// Valor Total constante no Documento de arrecadação 
        /// de Receita
        /// </summary>
        [XmlElement(elementName: "vDAR")]
        public string VDAR { get; set; }

        /// <summary>
        /// Repartição Fiscal emitente
        /// </summary>
        [XmlElement(elementName: "repEmi")]
        public string RepEmi { get; set; }

        /// <summary>
        /// Data de pagamento do Documento de Arrecadação
        /// <para>Formato "AAAA-MM-DD"</para>
        /// </summary>
        [XmlElement(elementName: "dPag")]
        public string DPag { get; set; }
    }
}
