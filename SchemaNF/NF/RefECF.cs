using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class RefECF
    {
        /// <summary>
        /// Modelo do Documento Fiscal
        /// <para>
        ///     Preencher com "2B", quando se tratar de Cupom 
        ///     Fiscal emitido por máquina registradora (não ECF), 
        ///     com "2C", quando se tratar de Cupom Fiscal PDV, ou
        ///     "2D", quando se tratar de Cupom Fiscal (emitido por ECF) (v2.0).
        /// </para>
        /// </summary>
        [XmlElement(elementName: "mod")]
        public string mod { get; set; }

        /// <summary>
        /// Número de ordem seqüencial do ECF 
        /// </summary>
        [XmlElement(elementName: "nECF")]
        public string nECF { get; set; }

        /// <summary>
        /// Número do Contador de Ordem de Operação - COO
        /// </summary>
        [XmlElement(elementName: "nCOO")]
        public string nCOO { get; set; }
    }
}
