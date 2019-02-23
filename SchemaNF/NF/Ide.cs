using System.Collections.Generic;
using System.Xml.Serialization;

namespace SchemaNF.NF
{
    public class Ide
    {
        /// <summary>
        /// Código da UF do emitente do Documento Fiscal. 
        /// Utilizar a Tabela do IBGE de código de
        /// unidades da federação (Anexo IV - Tabela de UF, 
        /// Município e País).
        /// </summary>
        [XmlElement(elementName: "cUF", Order =0)]
        public string CUF { get; set; }

        /// <summary>
        /// Chave de Acesso. Número aleatório gerado pelo emitente
        /// para cada NF-e para evitar acessos indevidos da NF-e. (v2.0)
        /// </summary>
        [XmlElement(elementName: "cNF", Order =1)]
        public string CNF { get; set; }

        /// <summary>
        /// Descrição da Natureza da Operação
        /// <para>
        ///     Informar a natureza da operação de que decorrer a
        ///     saída ou a entrada, tais como: venda, compra, 
        ///     transferência, devolução, importação, consignação,
        ///     remessa (para fins de demonstração, de 
        ///     industrialização ou outra), conforme previsto na
        ///     alínea 'i', inciso I, art. 19 do CONVÊNIO S/Nº, 
        ///     de 15 de dezembro de 1970.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "natOp", Order =2)]
        public string NatOp { get; set; }

        /// <summary>
        /// Indicador da forma de pagamento
        /// <para>0 – pagamento à vista</para>
        /// <para>1 – pagamento à prazo</para>
        /// <para>2 - outros</para>
        /// </summary>
        [XmlElement(elementName: "indPag", Order =3)]
        public string IndPag { get; set; }

        /// <summary>
        /// Código do Modelo do Documento Fiscal
        /// <para>
        ///     identificação da NF-e, emitida
        ///     em substituição ao modelo 1 ou 1A.
        ///     55=modelo da Nota Fiscal Eletrônica
        ///     65=modelo da NFC-e
        /// </para>
        /// </summary>
        [XmlElement(elementName: "mod", Order =4)]
        public string Mod { get; set; }

        /// <summary>
        /// Série do Documento Fiscal
        /// <para>
        ///     Preencher com zeros na hipótese de a NF-e 
        ///     não possuir série. (v2.0) 
        /// </para>
        /// <para>
        ///     Série 890-899 de uso exclusivo para emissão de 
        ///     NF-e avulsa, pelo contribuinte com seu certificado 
        ///     digital,  através do site do Fisco (procEmi=2). (v2.0)
        /// </para>
        /// <para>
        ///     Serie 900-999 – uso exclusivo de NF-e emitidas 
        ///     no SCAN. (v2.0)
        /// </para>
        /// </summary>
        [XmlElement(elementName: "serie", Order =5)]
        public string Serie { get; set; }

        /// <summary>
        /// Número do Documento Fiscal
        /// </summary>
        [XmlElement(elementName: "nNF", Order =6)]
        public string NNF { get; set; }

        /// <summary>
        /// Data de emissão do Documento Fiscal
        /// <para>Formato “AAAA-MM-DD”</para>
        /// </summary>
        [XmlElement(elementName: "dEmi", Order =7)]
        public string DEmi { get; set; }

        /// <summary>
        /// Data e Hora de emissão do Documento Fiscal
        /// 
        /// <para>
        /// Formato AAAA-MM-DDThh:mm:ssTZD (UTC - Universal Coordinated Time,
        /// onde TZD pode ser -02:00 (Fernando de Noronha), -03:00 (Brasília) ou -04:00
        /// (Manaus), no horário de verão serão - 01:00, -02:00 e -03:00. Ex.: 2010-08-
        /// 19T13:00:15-03:00.
        /// </para>
        /// <para>
        /// Nota: No caso da NF-e, a informação da Hora de Emissão é opcional, podendo
        /// ser informada com zeros.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "dhEmi", Order =8)]
        public string DhEmi { get; set; }

        /// <summary>
        /// Data de Saída ou da Entrada da Mercadoria/Produto
        /// <para>Formato "AAAA-MM-DD"</para>
        /// </summary>
        [XmlElement(elementName: "dSaiEnt", Order =9)]
        public string DSaiEnt { get; set; }

        /// <summary>
        /// Hora de Saída ou da Entrada da Mercadoria/Produto
        /// <para>Formato "HH:MM:SS" (v.2.0)</para>
        /// <para>Esse campo foi eliminado.(Documentação NFC-e)</para>
        /// </summary>
        [XmlElement(elementName: "hSaiEnt",Order =10)]
        public string HSaiEnt { get; set; }

        /// <summary>
        /// Data e Hora de Saída da Mercadoria/Produto. No caso da NF de
        /// entrada, esta é a Data e Hora de entrada.
        /// 
        /// <para>
        /// Formato AAAA-MM-DDThh:mm:ssTZD (UTC - Universal Coordinated Time,
        /// onde TZD pode ser -02:00 (Fernando de Noronha), -03:00 (Brasília) ou -04:00
        /// (Manaus), no horário de verão serão - 01:00, -02:00 e -03:00. Ex.: 2010-08-
        /// 19T13:00:15-03:00.
        /// </para>
        /// 
        /// <para>
        /// Nota: Para a NFC-e este campo não deve existir.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "dhSaiEnt", Order =11)]
        public string DhSaiEnt { get; set; }

        /// <summary>
        /// Tipo de Operação
        /// <para>0-entrada</para>
        /// <para>1-saída</para>
        /// </summary>
        [XmlElement(elementName: "tpNF", Order =12)]
        public string TpNF { get; set; }

        /// <summary>
        /// Identificador de local de destino da operação
        /// <para>
        /// 1- Operação interna
        /// 2- Operação interestadual
        /// 3- Operação com exterior
        /// </para>
        /// </summary>
        [XmlElement(elementName: "idDest", Order =13)]
        public string IdDest { get; set; }

        /// <summary>
        /// Código do Município de
        /// <para>
        ///     Informar o município de Ocorrência do 
        ///     Fato Gerador ocorrência do fato gerador do
        ///     ICMS. Utilizar a Tabela do IBGE (Anexo VII - 
        ///     Tabela de UF, Município e País)
        /// </para>
        /// </summary>
        [XmlElement(elementName: "cMunFG", Order =14)]
        public string CMunFG { get; set; }

        /// <summary>
        /// Formato de Impressão do DANFE
        /// <para>1 - Retrato</para>
        /// <para>2 - Paisagem</para>
        /// <para>3 - Simplificado</para>
        /// <para>4 - NFC-e</para>
        /// <para>5 - NFC-e mensagem eletronica</para>
        /// 
        /// <para>
        /// Nota: O envio de mensagem eletrônica pode ser feita de forma simultânea com
        /// a impressão do DANFE. Usar o tpImp=5 quando esta for a única forma
        /// de disponibilização do DANFE.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "tpImp", Order =15)]
        public string TpImp { get; set; }

        /// <summary>
        /// Tipo de Emissão da NF-e
        /// <para>
        ///     1 – Normal – emissão normal
        /// </para>
        /// <para>
        ///     2 – Contingência FS – emissão em contingência 
        ///     com impressão do DANFE em Formulário de Segurança
        /// </para>
        /// <para>
        ///     3 – Contingência SCAN – emissão em contingência 
        ///     no Sistema de Contingência do Ambiente Nacional – SCAN;
        /// </para>
        /// <para>
        ///     4 – Contingência DPEC - emissão em contingência com
        ///     envio da Declaração Prévia de Emissão em Contingência –
        ///     DPEC;
        /// </para>
        /// <para>
        ///     5 – Contingência FS-DA - emissão em contingência com
        ///     impressão do DANFE em Formulário de Segurança para
        ///     Impressão de Documento Auxiliar de Documento Fiscal
        ///     Eletrônico (FS-DA).
        /// </para>
        /// <para>
        ///     6 – Contingência SVC-AN (SEFAZ Virtual
        ///     de Contingência do AN);
        /// </para>
        /// <para>
        ///     7 – Contingência SVC-RS (SEFAZ Virtual
        ///     de Contingência do RS);
        /// </para>
        /// <para>
        ///     9 – Contingência off-line da NFC-e (as
        ///     demais opções de contingência são
        ///     válidas também para a NFC-e);
        ///     Nota: As opções de contingência 3,
        /// </para>
        /// </summary>
        [XmlElement(elementName: "tpEmis", Order =16)]
        public string TpEmis { get; set; }

        /// <summary>
        /// Dígito Verificador da Chave de Acesso da NF-e
        /// <para>
        ///     Informar o DV da Chave de Acesso da NF-e, 
        ///     o DV será calculado com a aplicação do 
        ///     algoritmo módulo 11 (base 2,9) da Chave de 
        ///     Acesso. (vide item 5 do Manual de Integração)
        /// </para>
        /// </summary>
        [XmlElement(elementName: "cDV", Order =17)]
        public string CDV { get; set; }

        /// <summary>
        /// Identificação do Ambiente
        /// <para>1 - Produção</para>
        /// <para>2 - Homologação</para>
        /// </summary>
        [XmlElement(elementName: "tpAmb", Order =18)]
        public string TpAmb { get; set; }

        /// <summary>
        /// CNPJ Software House
        /// Informar o CNPJ da empresa desenvolvedora do Aplicativo Comercial, 
        /// com os zeros não significativos.
        /// </summary>
        [XmlElement(elementName: "CNPJ", Order =19)]
        public string CNPJ { get; set; }

        /// <summary>
        /// Assinatura do Aplicativo Comercial
        /// Assinatura de (CNPJ Software House + CNPJ Emitente) que gerou o CF-e
        /// </summary>
        [XmlElement(elementName: "signAC", Order =20)]
        public string SignAC { get; set; }

        /// <summary>
        /// Número do Caixa ao qual o SAT está conectado
        /// </summary>
        [XmlElement(elementName: "numeroCaixa", Order =21)]
        public string NumeroCaixa { get; set; }

        /// <summary>
        /// Finalidade de emissão da NFe
        /// <para>1 - NF-e normal</para>
        /// <para>2 - NF-e complementar</para>
        /// <para>3 - NF-e de ajuste</para>
        /// </summary>
        [XmlElement(elementName: "finNFe", Order =22)]
        public string FinNFe { get; set; }

        /// <summary>
        /// Indica operação com Consumidor final
        /// <para>
        /// 0- Não;
        /// 1- Consumidor final;
        /// </para>
        /// </summary>
        [XmlElement(elementName: "indFinal", Order =23)]
        public string IndFinal { get; set; }

        /// <summary>
        /// Indicador de presença do comprador
        /// no estabelecimento comercial no
        /// momento da operação
        /// 
        /// <para>
        ///     0- Não se aplica (por exemplo, Nota
        ///     Fiscal complementar ou de ajuste);
        /// </para>
        /// 
        /// <para>
        ///     1- Operação presencial
        /// </para>
        /// 
        /// <para>
        ///     2- Operação não presencial, pela Internet;
        /// </para>
        /// 
        /// <para>
        ///     3- Operação não presencial, Teleatendimento;
        /// </para>
        /// 
        /// <para>
        ///     4- NFC-e em operação com entrega a domicílio; 
        /// </para>
        /// 
        /// <para>
        ///     5- Operação presencial, fora do estabelecimento; 
        /// </para>
        /// 
        /// <para>
        ///     9- Operação não presencial, outros.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "indPres", Order =24)]
        public string IndPres { get; set; }

        /// <summary>
        /// Processo de emissão da NF-e
        /// <para>
        ///     0 - emissão de NF-e com aplicativo do contribuinte
        /// </para>
        /// <para>
        ///     1 - emissão de NF-e avulsa pelo Fisco
        /// </para>
        /// <para>
        ///     2 - emissão de NF-e avulsa, pelo contribuinte com 
        ///     seu certificado digital, através do site do Fisco
        /// </para>
        /// <para>
        ///     3- emissão NF-e pelo contribuinte com aplicativo 
        ///     fornecido pelo Fisco.
        /// </para>
        /// </summary>
        [XmlElement(elementName: "procEmi", Order =25)]
        public string ProcEmi { get; set; }

        /// <summary>
        /// Versão do Processo de emissão da NF-e
        /// </summary>
        [XmlElement(elementName: "verProc", Order =26)]
        public string VerProc { get; set; }

        /// <summary>
        /// Data e Hora da entrada em contingência
        /// <para>
        /// Formato AAAA-MM-DDThh:mm:ssTZD (UTC - Universal Coordinated Time,
        /// onde TZD pode ser -02:00 (Fernando de Noronha), -03:00 (Brasília) ou -04:00
        /// (Manaus), no horário de verão serão -01:00, -02:00 e -03:00. Ex.: 2010-08-
        /// 19T13:00:15-03:00.s
        /// </para>
        /// </summary>
        [XmlElement(elementName: "dhCont", Order =27)]
        public string DhCont { get; set; }

        /// <summary>
        /// Justificativa da entrada em contingência
        /// </summary>
        [XmlElement(elementName: "xJust", Order =28)]
        public string XJust { get; set; }

        /// <summary>
        /// Grupo de informação das NF/NF-e referenciadas
        /// <para>
        ///     Grupo com as informações das NF/NF-e 
        ///     /NF de produtor/ Cupom Fiscal referenciadas.
        ///     Esta informação será utilizada nas hipóteses 
        ///     previstas na legislação. (Ex.: Devolução de
        ///     Mercadorias, Substituição de NF cancelada, 
        ///     Complementação de NF, etc.). (v.2.0)
        /// </para>
        /// </summary>
        [XmlElement(elementName: "NFref", Order =29)]
        public List<NFref> NFref { get; set; }
    }
}
