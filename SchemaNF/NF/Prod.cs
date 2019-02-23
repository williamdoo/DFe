using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Prod
    {
        /// <summary>
        /// Código do produto ou serviço
        /// <para>
        ///     Preencher com CFOP, caso se trate de itens não 
        ///     relacionados com mercadorias/produtos e que o 
        ///     contribuinte não possua codificação própria.
        ///     Formato "CFOP9999"
        /// </para>
        /// </summary>
        [XmlElement(elementName: "cProd")]
        public string CProd { get; set; }

        /// <summary>
        /// GTIN (Global Trade Item do produto, antigo código 
        /// EAN ou código de barras
        /// </summary>
        [XmlElement(elementName: "cEAN")]
        public string CEAN { get; set; }

        /// <summary>
        /// Descrição do produto ou serviço
        /// </summary>
        [XmlElement(elementName: "xProd")]
        public string XProd { get; set; }

        /// <summary>
        /// Código NCM com 8 dígitos ou 2 dígitos (gênero)
        /// <para>Em caso de serviço informar 99</para>
        /// </summary>
        [XmlElement(elementName: "NCM")]
        public string NCM { get; set; }

        /// <summary>
        /// Codificação NVE - Nomenclatura de Valor Aduaneiro e Estatística.
        /// </summary>
        [XmlElement(elementName: "NVE")]
        public string NVE { get; set; }

        /// <summary>
        /// Código Especificador da Substituição Tributária – CEST, 
        /// <para>que estabelece a sistemática de uniformização e identificação das mercadorias </para>
        /// <para>e bens passíveis de sujeição aos regimes de substituição tributária e de antecipação de recolhimento do ICMS</para>
        /// </summary>
        [XmlElement(elementName: "CEST")]
        public string CEST { get; set; }

        /// <summary>
        /// Indicador de Escala Relevante
        /// <para>
        /// Indicador de Produção em escala relevante, conforme Cláusula 23 do Convenio ICMS 52/2017: 
        /// </para>
        /// <para>
        /// S -  Produzido em Escala Relevante; N – Produzido em Escala NÃO Relevante.  
        /// </para>
        /// <para>
        /// Nota: preenchimento obrigatório para produtos com NCM relacionado no Anexo XXVII do Convenio 52/2017  
        /// </para>
        /// </summary>
        [XmlElement(elementName: "indEscala")]
        public string IndEscala { get; set; }

        /// <summary>
        /// CNPJ do Fabricante da Mercadoria
        /// <para>
        /// CNPJ do Fabricante da Mercadoria, obrigatório para produto em escala NÃO relevante. 
        /// </para>
        /// </summary>
        [XmlElement(elementName: "CNPJFab")]
        public string CNPJFab { get; set; }

        /// <summary>
        /// Código de Benefício Fiscal na UF aplicado ao item 
        /// <para>
        /// Código de Benefício Fiscal utilizado pela UF, aplicado ao item
        /// </para>
        /// <para>
        /// Obs.: Deve ser utilizado o mesmo código adotado na EFD e outras declarações, nas UF que o exigem
        /// </para>
        /// </summary>
        [XmlElement(elementName: "")]
        public string CBenef { get; set; }

        /// <summary>
        /// EX_TIPI
        /// <para>
        ///     Preencher de acordo com o código EX da TIPI. 
        ///     Em caso de serviço, não incluir a TAG.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "EXTIPI")]
        public string EXTIPI { get; set; }

        /// <summary>
        /// Código Fiscal de Operações e Prestações
        /// </summary>
        [XmlElement(elementName: "CFOP")]
        public string CFOP { get; set; }

        /// <summary>
        /// Unidade Comercial
        /// </summary>
        [XmlElement(elementName: "uCom")]
        public string UCom { get; set; }

        /// <summary>
        /// Quantidade Comercial
        /// </summary>
        [XmlElement(elementName: "qCom")]
        public string QCom { get; set; }

        /// <summary>
        /// <para>
        ///     Valor Unitário de Comercialização
        /// </para>
        /// <para>
        ///     Informar o valor unitário de comercialização do 
        ///     produto, campo meramente informativo, o contribuinte 
        ///     pode utilizar a precisão desejada (0-10 decimais). 
        ///     Para efeitos de cálculo, o valor unitário será obtido 
        ///     pela divisão do valor do produto pela quantidade 
        ///     comercial. (v2.0)
        /// </para>
        /// </summary>
        [XmlElement(elementName: "vUnCom")]
        public string VUnCom { get; set; }

        /// <summary>
        /// Valor Total Bruto dos Produtos
        /// </summary>
        [XmlElement(elementName: "vProd")]
        public string VProd { get; set; }

        /// <summary>
        /// GTIN (Global Trade Item do produto, antigo código 
        /// EAN ou código de barras
        /// </summary>
        [XmlElement(elementName: "cEANTrib")]
        public string CEANTrib { get; set; }

        /// <summary>
        /// Unidade Tributável
        /// </summary>
        [XmlElement(elementName: "uTrib")]
        public string UTrib { get; set; }

        /// <summary>
        /// Quantidade Tributável
        /// </summary>
        [XmlElement(elementName: "qTrib")]
        public string QTrib { get; set; }

        /// <summary>
        /// Valor Unitário de tributação
        /// <para>
        ///     Informar o valor unitário de tributação do produto, 
        ///     campo meramente informativo, o contribuinte pode 
        ///     utilizar a precisão desejada (0-10 decimais). Para 
        ///     efeitos de cálculo, o valor unitário será obtido 
        ///     pela divisão do valor do produto pela quantidade 
        ///     tributável.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "vUnTrib")]
        public string VUnTrib { get; set; }

        /// <summary>
        /// Valor Total do Frete
        /// </summary>
        [XmlElement(elementName: "vFrete")]
        public string VFrete { get; set; }

        /// <summary>
        /// Valor Total do Seguro
        /// </summary>
        [XmlElement(elementName: "vSeg")]
        public string VSeg { get; set; }

        /// <summary>
        /// Regra de cálculo
        /// Indicador da regra de cálculo utilizada para Valor
        /// Bruto dos Produtos e Serviços:
        /// <para>A - Arredondamento </para>
        /// <para>T - Truncamento</para>
        /// </summary>
        [XmlElement(elementName: "indRegra")]
        public string IndRegra { get; set; }

        /// <summary>
        /// Valor do Desconto
        /// </summary>
        [XmlElement(elementName: "vDesc")]
        public string VDesc { get; set; }

        /// <summary>
        /// Outras despesas acessórias
        /// </summary>
        [XmlElement(elementName: "vOutro")]
        public string VOutro { get; set; }

        /// <summary>
        /// TAG de grupo do detalhamento das observações do Fisco
        /// </summary>
        [XmlElement(elementName: "obsFiscoDet")]
        public ObsFiscoDet ObsFiscoDet { get; set; }

        /// <summary>
        /// Indica se valor do Item (vProd) entra no valor total da 
        /// NF-e (vProd)
        /// <para>
        ///     0 – o valor do item (vProd) não compõe o valor 
        ///     total da NF-e (vProd)
        /// </para>
        /// <para>
        ///     1 – o valor do item (vProd) compõe o valor total 
        ///     da NF-e (vProd)
        /// </para>
        /// </summary>
        [XmlElement(elementName: "indTot")]
        public string IndTot { get; set; }

        /// <summary>
        /// Tag da Declaração de Importação
        /// </summary>
        [XmlElement(elementName: "DI")]
        public DI DI { get; set; }

        /// <summary>
        /// Número do Pedido de Compra
        /// </summary>
        [XmlElement(elementName: "xPed")]
        public string XPed { get; set; }

        /// <summary>
        /// Item do Pedido de Compra
        /// </summary>
        [XmlElement(elementName: "nItemPed")]
        public string NItemPed { get; set; }

        /// <summary>
        /// Detalhamento de produto sujeito a rastreabilidade 
        /// </summary>
        [XmlElement(elementName: "rastro")]
        public List<Rastro> Rastro { get; set; }

        /// <summary>
        /// Grupo do detalhamento de Veículos novos
        /// </summary>
        [XmlElement(elementName: "veicProd")]
        public VeicProd VeicProd { get; set; }

        /// <summary>
        /// Grupo do detalhamento de Medicamentos e de 
        /// matérias primas farmacêuticas
        /// </summary>
        [XmlElement(elementName: "")]
        public Med Med { get; set; }

        /// <summary>
        /// Grupo do detalhamento de Armamento
        /// </summary>
        [XmlElement(elementName: "arma")]
        public Arma Arma { get; set; }

        /// <summary>
        /// Grupo de informações específicas para combustíveis
        /// líquidos e lubrificantes
        /// </summary>
        [XmlElement(elementName: "comb")]
        public Comb Comb { get; set; }
    }
}
