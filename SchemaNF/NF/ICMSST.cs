using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class ICMSST
    {
        /// <summary>
        /// Origem da mercadoria
        /// <para>0 - Nacional</para>
        /// <para>1 - Estrangeira - Importação direta</para>
        /// <para>2 - Estrangeira - Adquirida no meracado interno</para>
        /// </summary>
        [XmlElement(elementName: "orig")]
        public string Orig { get; set; }

        /// <summary>
        /// Tributação do ICMS:
        /// <para>
        ///     Tributação pelo ICMS 41 – Não Tributado (v2.0</para>
        /// </summary>
        [XmlElement(elementName: "CST")]
        public string CST { get; set; }

        /// <summary>
        /// Valor do BC do ICMS ST retido na UF remetente
        /// </summary>
        [XmlElement(elementName: "vBCSTRet")]
        public string VBCSTRet { get; set; }

        /// <summary>
        /// Valor do ICMS ST retido na UF remetente
        /// </summary>
        [XmlElement(elementName: "vICMSSTRet")]
        public string VICMSSTRet { get; set; }

        /// <summary>
        /// Valor da BC do ICMS ST da UF destino
        /// </summary>
        [XmlElement(elementName: "vBCSTDest")]
        public string VBCSTDest { get; set; }

        /// <summary>
        /// Valor do ICMS ST da UF destino
        /// </summary>
        [XmlElement(elementName: "vICMSSTDest")]
        public string VICMSSTDest { get; set; }
    }
}
