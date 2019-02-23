using Aplicacao;
using Certificado;
using SchemaNF.NF;
using System;
using System.IO;
using System.Linq;
using Wsdl.EnderecoWS;

namespace EmissaoNF
{
    public class App
    {
        /// <summary>
        /// Mensagem de erro
        /// </summary>
        public string Erro { get; set; }

        /// <summary>
        /// Assinatura Digital para assinar o documento fiscal utilizando o certificado do cliente
        /// </summary>
        protected AssinaturaDigital AssinaturaDigital { get; set; }

        /// <summary>
        /// Lista de websevice relacionado ao sistema de documentos fiscais eletrônicos
        /// </summary>
        protected WebServices ListaWebService { get; set; }

        /// <summary>
        /// Relizar a validação do documento fiscal com o arquivo .XSD
        /// </summary>
        protected ValidarDocumentoFiscal ValidarSchemaDocFiscal { get; set; }

        /// <summary>
        /// Web Service da NFe atual
        /// </summary>
        protected EnderecoWS WebServiceNFe { get; set; }

        /// <summary>
        /// Web Service da NFCe atual
        /// </summary>
        protected EnderecoNFCe WebServiceNFCe { get; set; }

        /// <summary>
        /// URL do QR Code atual
        /// </summary>
        protected string URLQRCode { get; set; }

        /// <summary>
        /// URL de consulta para chave da NFC-e atual
        /// </summary>
        protected string URLConsultaChave { get; set; }

        /// <summary>
        /// Certificado do cliente A1 ou A4
        /// </summary>
        protected CertificadoDigital Certificado { get; set; }
       
        /// <summary>
        /// Obtem ou informa o tempo de espera da tentativa de execução do Web Service (tempo em Milissegundos "Padrão 30000") 
        /// </summary>
        public int TimeOut { get; set; } = 30000;

        /// <summary>
        /// Sufixo do pedido de status de serviço (padrão -Stat-Serv)
        /// </summary>
        public string SufixoStatus { get; set; } = "-Stat-Serv";
        /// <summary>
        /// Sufixo da situação do status serviço (padrão -Sit-Serv)
        /// </summary>
        public string SufixoSituacaoServico { get; set; } = "-Sit-Serv";

        /// <summary>
        /// Sufixo do envio do lote (padrão -Env-Lote)
        /// </summary>
        public string SufixoLote { get; set; } = "-Env-Lote";

        /// <summary>
        /// Sufixo da nota fiscal (padrão -NFe)
        /// </summary>
        public string SufixoNFe { get; set; } = "-NFe";

        /// <summary>
        /// Sufixo do Pedido do Recibo (padrão -Ped-Rec)
        /// </summary>
        public string SufixoPedRec { get; set; } = "-Ped-Rec";

        /// <summary>
        /// Sufixo da protocolo do recibo (padrão -Pro-Rec)
        /// </summary>
        public string SufixoProRec { get; set; } = "-Pro-Rec";

        /// <summary>
        /// Sufixo da protocolo de autorizacao NFe (padrão -ProcNFe)
        /// </summary>
        public string SufixoProcNFe { get; set; } = "-ProcNFe";

        /// <summary>
        /// Pasta dos arquivos xml onde serão salvos (padrão NFe)
        /// </summary>
        public string PastaXML { get; set; } = "NFe";

        /// <summary>
        /// Chave da NF-e
        /// </summary>
        public string ChaveNFe { get; private set; }

        /// <summary>
        /// Id Token para NFC-e
        /// </summary>
        public string IDToken { get; set; }

        /// <summary>
        /// CSC da NFC-e
        /// </summary>
        public string CSC { get; set; }
        /// <summary>
        /// Protocolo de autorização
        /// </summary>
        public string ProtocoloAutorizacao { get; protected set; }

        /// <summary>
        /// Data e hora do protocolo de autorização
        /// </summary>
        public string DataHoraAutorizacao { get; protected set; }

        /// <summary>
        /// Obtem o caminho da pasta com o arquivo xml
        /// </summary>
        /// <param name="nomeArquivo">Nome do arquivo</param>
        /// <returns>Retorna o caminho da pasta e do arquivo XML</returns>
        public string ObterCaminhoArquivo(string nomeArquivo)
        {
            if (!Directory.Exists(PastaXML))
            {
                Directory.CreateDirectory(PastaXML);
            }

            return Path.Combine(PastaXML, nomeArquivo);
        }

        public bool GerarChaveNF(NFe nf)
        {
            try
            {
                string multiplicador = "4329876543298765432987654329876543298765432";
                int[] resultado = new int[43];
                Erro = "";
                string documento = nf.InfNFe.Emit.CNPJ ?? nf.InfNFe.Emit.CPF;

                if (nf.InfNFe.Ide == null)
                {
                    Erro = "Identificação da NFe não localizada.\n";
                }
                if (nf.InfNFe.Emit == null)
                {
                    Erro += "Emitente não localizado.\n";
                }
                if (string.IsNullOrEmpty(nf.InfNFe.Ide.CNF))
                {
                    nf.InfNFe.Ide.CNF = DateTime.Now.ToString("ddHHmmss");
                }
                if (string.IsNullOrEmpty(nf.InfNFe.Ide.DhEmi))
                {
                    Erro += "Data de emissão não informada.\n";
                }
                if (string.IsNullOrEmpty(nf.InfNFe.Ide.Mod))
                {
                    Erro += "Modelo não informado.\n";
                }
                if (string.IsNullOrEmpty(nf.InfNFe.Ide.NNF))
                {
                    Erro += "Número da NF não informado.\n";
                }
                if (string.IsNullOrEmpty(nf.InfNFe.Ide.TpEmis))
                {
                    Erro += "Tipo de Emissão de informado.\n";
                }
                if (string.IsNullOrEmpty(nf.InfNFe.Ide.CNF))
                {
                    Erro += "Chave da NF inválida.\n";
                }
                if (string.IsNullOrEmpty(nf.InfNFe.Ide.CUF))
                {
                    Erro += "Código IBGE do cliente não localizado.\n";
                }
                if (string.IsNullOrEmpty(nf.InfNFe.Ide.CUF))
                {
                    Erro += "Código IBGE do cliente não localizado.\n";
                }
                if (string.IsNullOrEmpty(documento))
                {
                    Erro += "Documento do emitente não localizado.\n";
                }
                if (!string.IsNullOrWhiteSpace(Erro))
                {
                    return false;
                }

                ChaveNFe = $"{nf.InfNFe.Ide.CUF}" +
                           $"{nf.InfNFe.Ide.DhEmi.Substring(2, 2)}" +
                           $"{nf.InfNFe.Ide.DhEmi.Substring(5, 2)}" +
                           $"{documento}" +
                           $"{nf.InfNFe.Ide.Mod}" +
                           $"{nf.InfNFe.Ide.Serie.PadLeft(3,'0')}" +
                           $"{nf.InfNFe.Ide.NNF.PadLeft(9, '0')}" +
                           $"{nf.InfNFe.Ide.TpEmis}" +
                           $"{nf.InfNFe.Ide.CNF}";

                if (ChaveNFe.Length != 43)
                {
                    Erro = "Chave da NF-e com tamanho não válido";
                    return false;
                }

                for(int i =0; i<ChaveNFe.Length; i++)
                {
                    resultado[i] = int.Parse(ChaveNFe[i].ToString()) * int.Parse(multiplicador[i].ToString());
                }

                int resto = resultado.Sum() % 11;
                string digito = "0";

                if(resto!=0 && resto != 1)
                {
                    digito = (11 - resto).ToString();
                }

                ChaveNFe += digito;

                nf.InfNFe.Ide.CDV = digito;
                nf.InfNFe.Id = "NFe" + ChaveNFe;
                return true;
            }
            catch(Exception ex)
            {
                Erro = $"ERRO NA GERAÇÃO DA CHAVE NF-E\n\n{ex.Message}";

                return false;
            }
        }

        public void CarregarWebService(WebServices ws)
        {
            ListaWebService = ws;
        }

        protected bool SetarWebService(string tpDoc, Estados.UF estado, EnderecoWS.Ambientes ambitente, string servico)
        {
            if (ListaWebService == null)
            {
                throw new Exception("A lista de Web service não foi carregada");
            }

            switch (tpDoc)
            {
                case "NFe":
                    WebServiceNFe = ListaWebService.NFe.FirstOrDefault(t => t.Ambiente == ambitente && t.Estado == estado && t.Servico == servico) ?? null;
                    
                    if (WebServiceNFe != null)
                    {
                        return true;
                    }

                    return false;
                case "NFCe":
                    WebServiceNFCe = ListaWebService.NFCe.FirstOrDefault(t => t.Ambiente == ambitente && t.Estado == estado && t.Servico == servico) ?? null;

                    if (WebServiceNFCe != null)
                    {
                        return true;
                    }

                    return false;
            }

            return false;
        }
    }
}
 