﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Aplicacao
{
    /// <summary>
    /// Classe de estados
    /// </summary>
    public class Estados
    {
        /// <summary>
        /// Estados
        /// </summary>
        [Flags]
        public enum UF
        {
            /// <summary>
            /// Acre
            /// </summary>
            [XmlEnum("12")]
            AC = 12,

            /// <summary>
            /// Alagoas
            /// </summary>
            [XmlEnum("27")]
            AL = 27,

            /// <summary>
            /// Amapá
            /// </summary>
            [XmlEnum("16")]
            AP = 16,

            /// <summary>
            /// Amazonas
            /// </summary>
            [XmlEnum("13")]
            AM = 13,

            /// <summary>
            /// Bahia
            /// </summary>
            [XmlEnum("29")]
            BA = 29,

            /// <summary>
            /// Ceará
            /// </summary>
            [XmlEnum("23")]
            CE = 23,

            /// <summary>
            /// Distrito Federal
            /// </summary>
            [XmlEnum("53")]
            DF = 53,

            /// <summary>
            /// Espírito Santo
            /// </summary>
            [XmlEnum("32")]
            ES = 32,

            /// <summary>
            /// Goiás
            /// </summary>
            [XmlEnum("52")]
            GO = 52,

            /// <summary>
            /// Maranhão
            /// </summary>
            [XmlEnum("21")]
            MA = 21,

            /// <summary>
            /// Mato Grosso
            /// </summary>
            [XmlEnum("51")]
            MT = 51,

            /// <summary>
            /// Mato Grosso do Sul
            /// </summary>
            [XmlEnum("50")]
            MS = 50,

            /// <summary>
            /// Minas Gerais
            /// </summary>
            [XmlEnum("31")]
            MG = 31,

            /// <summary>
            /// Pará
            /// </summary>
            [XmlEnum("15")]
            PA = 15,

            /// <summary>
            /// Paraíba
            /// </summary>
            [XmlEnum("25")]
            PB = 25,

            /// <summary>
            /// Paraná
            /// </summary>
            [XmlEnum("41")]
            PR = 41,

            /// <summary>
            /// Pernambuco
            /// </summary>
            [XmlEnum("26")]
            PE = 26,

            /// <summary>
            /// Piauí
            /// </summary>
            [XmlEnum("22")]
            PI = 22,

            /// <summary>
            /// Rio de Janeiro
            /// </summary>
            [XmlEnum("33")]
            RJ = 33,

            /// <summary>
            /// Rio Grande do Norte
            /// </summary>
            [XmlEnum("24")]
            RN = 24,

            /// <summary>
            /// Rio Grande do Sul
            /// </summary>
            [XmlEnum("43")]
            RS = 43,

            /// <summary>
            /// Rondônia
            /// </summary>
            [XmlEnum("11")]
            RO = 11,

            /// <summary>
            /// Roraima
            /// </summary>
            [XmlEnum("14")]
            RR = 14,

            /// <summary>
            /// Santa Catarina
            /// </summary>
            [XmlEnum("42")]
            SC = 42,

            /// <summary>
            /// São Paulo
            /// </summary>
            [XmlEnum("35")]
            SP = 35,

            /// <summary>
            /// Sergipe
            /// </summary>
            [XmlEnum("28")]
            SE = 28,

            /// <summary>
            /// Tocantins
            /// </summary>
            [XmlEnum("17")]
            TO = 17,

            /// <summary>
            /// Exterior
            /// </summary>
            [XmlEnum("99")]
            EX = 99
        }

        /// <summary>
        /// Obtem o estado
        /// </summary>
        /// <param name="CodIBGE">Códgio IBGE</param>
        /// <returns>Retorna um estado</returns>
        public static UF ObterEstado(string CodIBGE)
        {
            switch (CodIBGE)
            {
                case "35":
                    return UF.SP;
                default:
                    return UF.EX;
            }
        }

        /// <summary>
        /// Obtem o estado
        /// </summary>
        /// <param name="uf">Estado</param>
        /// <returns>Retorna o códido IBGE do estado</returns>
        public static string ObterEstado(UF uf)
        {
            switch (uf)
            {
                case UF.SP:
                    return "35";
                default:
                    return "99";
            }
        }
    }
}
