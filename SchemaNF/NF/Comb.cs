using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Comb
    {
        /// <summary>
        /// Código de produto da ANP
        /// <para>
        ///     Utilizar a codificação de produtos do Sistema de
        ///     Informações de Movimentação de produtos - SIMP
        ///     (http://www.anp.gov.br/simp/index.htm). 
        /// </para>
        /// <para>
        ///     Informar 999999999 se o produto não possuir código 
        ///     de produto ANP.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "cProdANP")]
        public string CProdANP { get; set; }

        /// <summary>
        /// Código de autorização / registro do CODIF
        /// <para>
        ///     Informar apenas quando a UF utilizar o CODIF 
        ///     (Sistema de Controle do Diferimento do Imposto 
        ///     nas Operações com AEAC - Álcool Etílico Anidro
        ///     Combustível).
        /// </para>
        /// </summary>
        [XmlElement(elementName: "CODIF")]
        public string CODIF { get; set; }

        /// <summary>
        /// Quantidade de combustível faturada à temperatura ambiente
        /// <para>
        ///     Informar quando a quantidade faturada informada no campo
        ///     qCom (I10) tiver sido ajustada para uma temperatura 
        ///     diferente da ambiente.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "qTemp")]
        public string QTemp { get; set; }

        /// <summary>
        /// Sigla da UF de consumo
        /// </summary>
        [XmlElement(elementName: "UFCons")]
        public string UFCons { get; set; }

        /// <summary>
        /// Grupo da CIDE
        /// </summary>
        [XmlElement(elementName: "CIDE")]
        public CIDE CIDE { get; set; }
    }
}
