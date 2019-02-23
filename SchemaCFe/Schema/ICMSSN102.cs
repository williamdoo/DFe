using System.Xml.Serialization;

namespace SchemaCFe.Schema
{
    public class ICMSSN102
    {
        /// <summary>
        /// Origem da mercadoria
        /// </summary>
        [XmlElement(ElementName = "Orig")]
        public string Orig { get; set; }

        /// <summary>
        /// Código de Situação da Operação – Simples Nacional
        /// <para>102- Tributada pelo Simples Nacional sem permissão de crédito.</para>
        /// <para>300 – Imune</para>
        /// <para>400 – Não tributada</para>
        /// </summary>
        [XmlElement(ElementName = "CSOSN")]
        public string CSOSN { get; set; }
    }
}