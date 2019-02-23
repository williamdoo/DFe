using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Arma
    {
        /// <summary>
        /// Indicador do tipo de arma de fogo
        /// <para>0 - Uso permitido</para>
        /// <para>1 - Uso restrito</para>
        /// </summary>
        [XmlElement(elementName: "tpArma")]
        public string TpArma { get; set; }

        /// <summary>
        /// Número de série da arma
        /// </summary>
        [XmlElement(elementName: "nSerie")]
        public string NSerie { get; set; }

        /// <summary>
        /// Número de série do cano
        /// </summary>
        [XmlElement(elementName: "nCano")]
        public string NCano { get; set; }

        /// <summary>
        /// Descrição completa da arma, compreendendo: calibre,
        /// marca, capacidade, tipo de funcionamento, comprimento e
        /// demais elementos que permitam a sua perfeita identificação.
        /// </summary>
        [XmlElement(elementName: "descr")]
        public string Descr { get; set; }
    }
}
