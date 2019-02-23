using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class VeicProd
    {
        /// <summary>
        /// Tipo da operação
        /// <para>1 – Venda concessionária</para>
        /// <para>2 – Faturamento direto para consumidor final</para>
        /// <para>3 – Venda direta para grandes consumidores (frotista, governo, ...)</para>
        /// <para>0 – Outros</para>
        /// </summary>
        [XmlElement(elementName: "tpOp")]
        public string TpOp { get; set; }

        /// <summary>
        /// Chassi do veículo
        /// </summary>
        [XmlElement(elementName: "chassi")]
        public string Chassi { get; set; }

        /// <summary>
        /// Cor (código de cada montadora)
        /// </summary>
        [XmlElement(elementName: "cCor")]
        public string CCor { get; set; }

        /// <summary>
        /// Descrição da Cor
        /// </summary>
        [XmlElement(elementName: "xCor")]
        public string XCor { get; set; }

        /// <summary>
        /// Potência Motor (CV)
        /// </summary>
        [XmlElement(elementName: "pot")]
        public string Pot { get; set; }

        /// <summary>
        /// Cilindradas
        /// </summary>
        [XmlElement(elementName: "cilin")]
        public string Cilin { get; set; }

        /// <summary>
        /// Peso Líquido
        /// </summary>
        [XmlElement(elementName: "pesoL")]
        public string PesoL { get; set; }

        /// <summary>
        /// Peso Bruto
        /// </summary>
        [XmlElement(elementName: "pesoB")]
        public string PesoB { get; set; }

        /// <summary>
        /// Serial (série)
        /// </summary>
        [XmlElement(elementName: "nSerie")]
        public string NSerie { get; set; }

        /// <summary>
        /// Tipo de combustível (Tabela RENAVAN)
        /// </summary>
        [XmlElement(elementName: "tpComb")]
        public string TpComb { get; set; }

        /// <summary>
        /// Número de Motor
        /// </summary>
        [XmlElement(elementName: "nMotor")]
        public string NMotor { get; set; }

        /// <summary>
        /// Capacidade Máxima de Tração
        /// </summary>
        [XmlElement(elementName: "CMT")]
        public string CMT { get; set; }

        /// <summary>
        /// Distância entre eixos
        /// </summary>
        [XmlElement(elementName: "dist")]
        public string Dist { get; set; }

        /// <summary>
        /// Ano Modelo de Fabricação
        /// </summary>
        [XmlElement(elementName: "anoMod")]
        public string AnoMod { get; set; }

        /// <summary>
        /// Ano de Fabricação
        /// </summary>
        [XmlElement(elementName: "anoFab")]
        public string AnoFab { get; set; }

        /// <summary>
        /// Tipo de Pintura
        /// </summary>
        [XmlElement(elementName: "tpPint")]
        public string TpPint { get; set; }

        /// <summary>
        /// Tipo de Veículo (Tabela RENAVAN)
        /// </summary>
        [XmlElement(elementName: "tpVeic")]
        public string TpVeic { get; set; }

        /// <summary>
        /// Espécie de Veículo (Tabela RENAVAN)
        /// </summary>
        [XmlElement(elementName: "espVeic")]
        public string EspVeic { get; set; }

        /// <summary>
        /// Condição do VIN
        /// </summary>
        [XmlElement(elementName: "VIN")]
        public string VIN { get; set; }

        /// <summary>
        /// Condição do Veículo
        /// <para>1 - Acabado</para>
        /// <para>2 - Inacabado</para>
        /// <para>2 - Semi-acabado</para>
        /// </summary>
        [XmlElement(elementName: "condVeic")]
        public string CondVeic { get; set; }

        /// <summary>
        /// Código Marca Modelo (Tabela RENAVAN)
        /// </summary>
        [XmlElement(elementName: "cMod")]
        public string CMod { get; set; }

        /// <summary>
        /// Código da Cor (Tabela RENAVAN)
        /// </summary>
        [XmlElement(elementName: "cCorDENATRAN")]
        public string CCorDENATRAN { get; set; }

        /// <summary>
        /// Capacidade máxima de lotação
        /// </summary>
        [XmlElement(elementName: "lota")]
        public string Lota { get; set; }

        /// <summary>
        /// Restrição
        /// <para>0 - Não há</para>
        /// <para>1 - Alienação Fiduciária</para>
        /// <para>2 - Arrendamento Mercantil</para>
        /// <para>3 - Reserva de Domínio</para>
        /// <para>4 - Penhor de Veículos</para>
        /// <para>9 - outras.</para>
        /// </summary>
        [XmlElement(elementName: "tpRest")]
        public string TpRest { get; set; }
    }
}
