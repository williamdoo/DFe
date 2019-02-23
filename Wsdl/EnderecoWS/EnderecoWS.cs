using Aplicacao;
using System;
using System.Xml.Serialization;

namespace Wsdl.EnderecoWS
{
    public class EnderecoWS
    {
        [Flags]
        public enum Ambientes
        {
            [XmlEnum("1")]
            Producao = 1,

            [XmlEnum("2")]
            Homologacao = 2
        }

        public string Servico { get; set; }
        public string WebService { get; set; }
        public Estados.UF Estado { get; set; }
        public Ambientes Ambiente { get; set; }

        public static Ambientes ObterAmbiemte(string tpAmb)
        {
            switch (tpAmb)
            {
                case "1":
                    return Ambientes.Producao;
                default:
                    return Ambientes.Homologacao;
            }
        }

        public static string ObterAmbiemte(Ambientes tpAmb)
        {
            switch (tpAmb)
            {
                case Ambientes.Producao:
                    return "1";
                default:
                    return "2";
            }
        }
    }
}
