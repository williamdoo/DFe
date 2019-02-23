using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchemaNF.RetEnvNF
{
    /// <summary>
    /// 
    /// </summary>
    public class InfRec
    {
        /// <summary>
        /// Número do Recibo gerado pelo Portal da Secretaria de Fazenda Estadual.
        /// </summary>
        [XmlElement(ElementName = "nRec")]
        public string NRec { get; set; }

        /// <summary>
        /// Tempo médio de resposta do serviço (em segundos) dos últimos 5 minutos.
        /// Nota: Caso o tempo médio de resposta fique
        /// abaixo de 1 (um) segundo, o tempo será
        /// informado como 1 segundo. Arredondar as
        /// frações de segundos para cima.
        /// </summary>
        [XmlElement(ElementName = "tMed")]
        public string TMed { get; set; }
    }
}
