using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Imposto
    {
        /// <summary>
        /// Valor aproximado total de tributos federais, estaduais e municipais
        /// </summary>
        [XmlElement(elementName: "vTotTrib")]
        public string VTotTrib { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "vItem12741")]
        public string VItem12741 { get; set; }

        /// <summary>
        /// Grupo do ICMS da Operação própria e ST
        /// </summary>
        [XmlElement(elementName: "ICMS")]
        public ICMS ICMS { get; set; }

        /// <summary>
        /// Grupo do IPI
        /// <para>Informar apenas quando o item for sujeito ao IPI</para>
        /// </summary>
        [XmlElement(elementName: "IPI")]
        public IPI IPI { get; set; }

        /// <summary>
        /// Grupo do II
        /// <para>Informar apenas quando o item for sujeito ao II</para>
        /// </summary>
        [XmlElement(elementName: "II")]
        public II II { get; set; }

        /// <summary>
        /// Grupo do PIS
        /// </summary>
        [XmlElement(elementName: "PIS")]
        public PIS PIS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "PISST")]
        public PISST PISST { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "COFINS")]
        public COFINS COFINS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "")]
        public COFINSST COFINSST { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(elementName: "")]
        public ISSQN ISSQN { get; set; }

        /// <summary>
        /// Informação do ICMS Interestadual
        /// </summary>
        [XmlElement(elementName: "ICMSUFDest")]
        public ICMSUFDest ICMSUFDest { get; set; }
    }
}
