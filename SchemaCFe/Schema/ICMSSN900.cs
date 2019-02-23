using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class ICMSSN900
    {
        /// <summary>
        /// Origem da mercadoria
        /// </summary>
        [XmlElement(ElementName = "Orig")]
        public string Orig { get; set; }

        /// <summary>
        /// Código de Situação da Operação – SIMPLES NACIONAL
        /// <para>900 - Outros</para>
        /// </summary>
        [XmlElement(ElementName = "CSOSN")]
        public string CSOSN { get; set; }

        /// <summary>
        /// Alíquota efetiva do imposto
        /// </summary>
        [XmlElement(ElementName = "pICMS")]
        public string PICMS { get; set; }

        /// <summary>
        /// Valor do ICMS
        /// </summary>
        [XmlElement(ElementName = "vICMS")]
        public string VICMS { get; set; }
    }
}