using Aplicacao;
using Certificado;
using SchemaNF.ConsReciboNFe;
using SchemaNF.ConsStatusServ;
using SchemaNF.Lote;
using SchemaNF.NF;
using SchemaNF.ProcNF;
using SchemaNF.RetConsReciboNFe;
using SchemaNF.RetConsStatusServ;
using SchemaNF.RetEnvNF;
using System;
using System.Data;
using System.Net;
using System.Xml;
using Wsdl.EnderecoWS;
using Wsdl.NFCe;

namespace EmissaoNF
{
    public class SistemaNF : App
    {

        /// <summary>
        /// Número do Recibo do protocolo de envio da NFe
        /// </summary>
        public string NumRecibo { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string CaminhoSchemaXSD { get; set; }

        /// <summary>
        /// Mensagem de retorno da SEFAZ
        /// </summary>
        public string Mensagem { get; set; }

        public SistemaNF()
        {
            
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            LiberarRecurso();
        }

        #region NFe
        public bool StatusNFe(EnderecoWS.Ambientes tpAmb, Estados.UF estado, string versao, string serialCertificado = null)
        {
            Mensagem = "";
            try
            {
                if (!SetarWebService("NFe", estado, tpAmb, "NFeStatusServico"))
                {
                    Erro = "Web Service não foi encontrado";
                    return false;
                }

                if (!Certificado.BuscarCertificado(nroSerie: serialCertificado))
                {
                    Erro = Certificado.Erros;
                    return false;
                }

                ConsStatServ consStatServ = ConsStartusServ(tpAmb, estado, versao);

                using (Wsdl.NFe.Status.NfeStatusServico4 ws = new Wsdl.NFe.Status.NfeStatusServico4(WebServiceNFCe.WebService, Certificado.X509Certificado, TimeOut))
                {
                    XmlNode node = ws.Execute(consStatServ.ToXmlDocument());

                    if (node == null)
                    {
                        throw new Exception($"Falha no envio do arquivo de retorno (404 - Serviço não encontrado).\n\nWeb Service {WebServiceNFCe.WebService}");
                    }
                    else
                    {
                        return RetornarConsStartusServ(node);
                    }
                }
            }
            catch (Exception ex)
            {
                Erro = $"ERRO NO PROCESSO DE VERIFICAR STATUS SERVIÇO\n\n{ex.Message}";
                return false;
            }
        }

        public bool EnviarNFe(NFe nfe, string idLote, string serialCertificado = "")
        {
            NumRecibo = "";

            try
            {
                if (!SetarWebService("NFe", Estados.ObterEstado(nfe.InfNFe.Ide.CUF), Wsdl.EnderecoWS.EnderecoWS.Ambientes.Homologacao, "NFeAutorizacao"))
                {
                    Erro = "Web Service não foi encontrado";
                    return false;
                }

                if (!GerarChaveNF(nfe))
                {
                    return false;
                }

                if (!Certificado.BuscarCertificado(nroSerie: serialCertificado))
                {
                    Erro = Certificado.Erros;
                    return false;
                }

                if (!Certificado.BuscarCertificado(nroSerie: serialCertificado))
                {
                    Erro = Certificado.Erros;
                    return false;
                }

                XmlDocument lote = CriarLoteEAssinar(nfe, idLote);

                using (Wsdl.NFe.Autorizacao.NFeAutorizacao4 ws = new Wsdl.NFe.Autorizacao.NFeAutorizacao4(WebServiceNFe.WebService, Certificado.X509Certificado, TimeOut))
                {
                    XmlNode n = ws.Execute(lote);

                    if (n == null)
                    {
                        throw new Exception($"Falha na obtenção do arquivo de retorno (404 - Serviço não encontrado).\n\nWeb Service {WebServiceNFe.WebService}");
                    }
                    else
                    {
                        return RetornoRecibo(n.OuterXml.ToXmlClass<RetEnviNFe>());
                    }
                }
            }
            catch (Exception ex)
            {
                Erro = $"ERRO NO PROCESSO DE ENVIO\n\n{ex.Message}";
                return false;
            }
        }

        public bool ConsultaSituacaoAtualNFe(string caminhoNFe, string numRec, string serialCertificado = null)
        {
            Mensagem = "";

            try
            {
                NFe nfe = ManipularXML.Load<NFe>(caminhoNFe);

                if (!SetarWebService("NFe", Estados.ObterEstado(nfe.InfNFe.Ide.CUF), EnderecoWS.ObterAmbiemte(nfe.InfNFe.Ide.TpAmb), "NFeRetAutorizacao"))
                {
                    Erro = "Web Service não foi encontrado";
                    return false;
                }

                if (!Certificado.BuscarCertificado(nroSerie: serialCertificado))
                {
                    Erro = Certificado.Erros;
                    return false;
                }

                XmlDocument recNfe = ConsReciboNF(nfe, numRec).ToXmlDocument();

                using (Wsdl.NFe.Autorizacao.NFeRetAutorizacao4 ws = new Wsdl.NFe.Autorizacao.NFeRetAutorizacao4(WebServiceNFe.WebService, Certificado.X509Certificado, TimeOut))
                {
                    bool tentarNovamente;
                    bool resultado;
                    do
                    {
                        tentarNovamente = false;
                        XmlNode n = ws.Execute(recNfe);
                        if (n == null)
                        {
                            throw new Exception($"Falha no envio do arquivo de retorno (404 - Serviço não encontrado).\n\nWeb Service {WebServiceNFCe.WebService}");
                        }
                        else
                        {
                            resultado = RetornoConsultaRecibo(nfe, n.OuterXml.ToXmlClass<RetConsReciNFe>(), caminhoNFe, out tentarNovamente);

                            if (!tentarNovamente)
                            {
                                return resultado;
                            }
                        }
                    } while (tentarNovamente);

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                Erro = $"ERRO NO PROCESSO DE CONSULTA ATUAL\n\n{ex.Message}";
                return false;
            }
        }
        #endregion

        #region NFCe
        public bool StatusNFCe(EnderecoWS.Ambientes tpAmb, Estados.UF estado, string versao, string serialCertificado=null)
        {
            Mensagem = "";
            try
            {
                if (!SetarWebService("NFCe", estado, tpAmb, "NFeStatusServico"))
                {
                    Erro = "Web Service não foi encontrado";
                    return false;
                }

                if (!Certificado.BuscarCertificado(nroSerie: serialCertificado))
                {
                    Erro = Certificado.Erros;
                    return false;
                }

                ConsStatServ consStatServ = ConsStartusServ(tpAmb, estado, versao);

                using (Wsdl.NFCe.Status.NfeStatusServico4 ws = new Wsdl.NFCe.Status.NfeStatusServico4(WebServiceNFCe.WebService, Certificado.X509Certificado, TimeOut))
                {
                    XmlNode node = ws.Execute(consStatServ.ToXmlDocument());

                    if (node == null)
                    {
                        throw new Exception($"Falha no envio do arquivo de retorno (404 - Serviço não encontrado).\n\nWeb Service {WebServiceNFCe.WebService}");
                    }
                    else
                    {
                        return RetornarConsStartusServ(node);
                    }
                }
            }
            catch (Exception ex)
            {
                Erro = $"ERRO NO PROCESSO DE VERIFICAR STATUS SERVIÇO\n\n{ex.Message}";
                return false;
            }
        }

        public bool EnviarNFCe(NFe nfce, string idLote, string serialCertificado = "")
        {
            NumRecibo = "";
            Mensagem = "";

            try
            {
                if (!SetarWebService("NFCe",  Estados.ObterEstado(nfce.InfNFe.Ide.CUF), EnderecoWS.ObterAmbiemte(nfce.InfNFe.Ide.TpAmb), "NFeAutorizacao"))
                {
                    Erro = "Web Service não foi encontrado";
                    return false;
                }

                if (!GerarChaveNF(nfce))
                {
                    return false;
                }

                if (!Certificado.BuscarCertificado(nroSerie: serialCertificado))
                {
                    Erro = Certificado.Erros;
                    return false;
                }

                XmlDocument lote = CriarLoteEAssinar(nfce, idLote, true);

                if (!ValidarDocumentoFiscal(ObterCaminhoArquivo($"{nfce.InfNFe.Id.Substring(3)}{SufixoNFe}.xml")))
                {
                    return false;
                }

                using (Wsdl.NFCe.Autorizacao.NFeAutorizacao4 ws = new Wsdl.NFCe.Autorizacao.NFeAutorizacao4(WebServiceNFCe.WebService, Certificado.X509Certificado, TimeOut))
                {
                    XmlNode n = ws.Execute(lote);

                    if (n == null)
                    {
                        throw new Exception($"Falha no envio do arquivo de retorno (404 - Serviço não encontrado).\n\nWeb Service {WebServiceNFCe.WebService}");
                    }
                    else
                    {
                        return RetornoRecibo(n.OuterXml.ToXmlClass<RetEnviNFe>());
                    }
                }
            }
            catch (Exception ex)
            {
                Erro = $"ERRO NO PROCESSO DE ENVIO\n\n{ex.Message}";
                return false;
            }
        }

        public bool ConsultaSituacaoAtualNFCe(string caminhoNFCe, string numRec, string serialCertificado=null)
        {
            Mensagem = "";

            try
            {
                NFe nfce = ManipularXML.Load<NFe>(caminhoNFCe);

                if (!SetarWebService("NFCe", Estados.ObterEstado(nfce.InfNFe.Ide.CUF), EnderecoWS.ObterAmbiemte(nfce.InfNFe.Ide.TpAmb), "NFeRetAutorizacao"))
                {
                    Erro = "Web Service não foi encontrado";
                    return false;
                }

                if (!Certificado.BuscarCertificado(nroSerie: serialCertificado))
                {
                    Erro = Certificado.Erros;
                    return false;
                }

                XmlDocument recNfe = ConsReciboNF(nfce, numRec).ToXmlDocument();

                using (Wsdl.NFCe.Autorizacao.NFeRetAutorizacao4 ws = new Wsdl.NFCe.Autorizacao.NFeRetAutorizacao4(WebServiceNFCe.WebService, Certificado.X509Certificado, TimeOut))
                {
                    bool tentarNovamente;
                    bool resultado;
                    do
                    {
                        tentarNovamente = false;
                        XmlNode n = ws.Execute(recNfe);
                        if (n == null)
                        {
                            throw new Exception($"Falha no envio do arquivo de retorno (404 - Serviço não encontrado).\n\nWeb Service {WebServiceNFCe.WebService}");
                        }
                        else
                        {                            
                            resultado = RetornoConsultaRecibo(nfce, n.OuterXml.ToXmlClass<RetConsReciNFe>(), caminhoNFCe, out tentarNovamente);

                            if (!tentarNovamente)
                            {
                                return resultado;
                            }
                        }
                    } while (tentarNovamente);

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                Erro = $"ERRO NO PROCESSO DE CONSULTA ATUAL\n\n{ex.Message}";
                return false;
            }
        }

        private string GerarQRCode(XmlDocument nfce)
        {
            QRCode qr = new QRCode();

            if (string.IsNullOrWhiteSpace(IDToken))
            {
                throw new Exception("Informe um ID Tokem");
            }

            if(string.IsNullOrWhiteSpace(CSC))
            {
                throw new Exception("Informe um CSC");
            }

            DataSet ds = new DataSet();
            XmlReader xmlReader = new XmlNodeReader(nfce);
            ds.ReadXml(xmlReader);

            qr.ChNfe = ds.Tables["infNFe"].Rows[0]["Id"].ToString().Replace("NFe", "");
            qr.NVersao = "2";
            qr.TpAmb = ds.Tables["ide"].Rows[0]["tpAmb"].ToString();
            qr.DhEmi = ds.Tables["ide"].Rows[0]["dhEmi"].ToString();
            qr.VNF = ds.Tables["ICMSTot"].Rows[0]["vNF"].ToString();

            if (ds.Tables["dest"] != null)
            {
                if (ds.Tables["dest"].Columns["CNPJ"]!=null)
                {
                    qr.CDest = ds.Tables["dest"].Rows[0]["CNPJ"].ToString();
                }
                else if (ds.Tables["dest"].Columns["CPF"]!=null)
                {
                    qr.CDest = ds.Tables["dest"].Rows[0]["CPF"].ToString();
                }
            }

            qr.VICMS = ds.Tables["ICMSTot"].Rows[0]["vICMS"].ToString();
            qr.DigVal = ds.Tables["Reference"].Rows[0]["DigestValue"].ToString();
            qr.CIdToken = IDToken.Replace(" ", "");
            qr.Csc = CSC;
            qr.URL = WebServiceNFCe.URLQRCode;
            qr.VersaoXML = ds.Tables["infNFe"].Rows[0]["versao"].ToString();
            qr.Contingencia = ds.Tables["ide"].Rows[0]["tpEmis"].ToString()=="9";
            qr.GerarURLQRCode();

            return $"<![CDATA[{qr.TextQRCode}]]>";
        }

        private void AdicionarQRCode(string qrCode, string enderecoConsulta, XmlDocument nfce)
        {
            if (nfce.DocumentElement["infNFeSupl"] != null)
            {
                XmlNode infNFeSupl = nfce.DocumentElement["infNFeSupl"];

                infNFeSupl.ChildNodes[0].InnerXml = qrCode;
                if (!string.IsNullOrWhiteSpace(enderecoConsulta))
                {
                    infNFeSupl.ChildNodes[1].InnerXml = enderecoConsulta;
                }
            }
            else
            {
                XmlElement infNFeSupl = nfce.CreateElement("infNFeSupl", "http://www.portalfiscal.inf.br/nfe");
                XmlElement tqrCode = nfce.CreateElement("qrCode", "http://www.portalfiscal.inf.br/nfe");
                XmlElement turlChave = nfce.CreateElement("urlChave", "http://www.portalfiscal.inf.br/nfe");
                XmlNode signature = nfce.DocumentElement["Signature"];

                tqrCode.InnerXml = qrCode;
                turlChave.InnerXml = enderecoConsulta;
                infNFeSupl.AppendChild(tqrCode);
                
                if (!string.IsNullOrWhiteSpace(enderecoConsulta))
                {
                    infNFeSupl.AppendChild(turlChave);
                }

                nfce.DocumentElement.InsertBefore(infNFeSupl, signature);
            }
        }
        #endregion

        private ConsStatServ ConsStartusServ(EnderecoWS.Ambientes tpAmb, Estados.UF estado, string versao)
        {
            ConsStatServ consStatServ = new ConsStatServ()
            {
                Versao = versao,
                TpAmb = EnderecoWS.ObterAmbiemte(tpAmb),
                CUF = Estados.ObterEstado(estado),
                XServ = "STATUS"
            };

            consStatServ.Salvar(ObterCaminhoArquivo($"Status{SufixoStatus}.xml"));

            return consStatServ;
        }

        private bool RetornarConsStartusServ(XmlNode node)
        {
            RetConsStatServ retConsStatServ = node.OuterXml.ToXmlClass<RetConsStatServ>();
            retConsStatServ.Salvar(ObterCaminhoArquivo($"Status{SufixoSituacaoServico}.xml"));

            if (retConsStatServ.CStat == "107" || retConsStatServ.CStat == "108" || retConsStatServ.CStat == "109")
            {
                Mensagem = $"{retConsStatServ.CStat}-{retConsStatServ.XMotivo}";
                return true;
            }
            else
            {
                Erro = $"{retConsStatServ.CStat}-{retConsStatServ.XMotivo}";
                return false;
            }
        }

        private XmlDocument CriarLoteEAssinar(NFe nf, string idLote, bool NFCe = false)
        {
            XmlDocument lote, xmlNFe;
            EnviNFe enviNFe = new EnviNFe();
            enviNFe.Versao = nf.InfNFe.Versao;
            enviNFe.IndSinc = "0";

            enviNFe.IdLote = idLote;

            lote = enviNFe.ToXmlDocument();
            if (!AssinaturaDigital.Assinar(nf.ToXmlString(), "infNFe", Certificado.X509Certificado))
            {
                throw new Exception(AssinaturaDigital.Erro);
            }

            xmlNFe = AssinaturaDigital.XMLDoc;

            if (NFCe)
            {
                AdicionarQRCode(GerarQRCode(xmlNFe), WebServiceNFCe.EnderecoQRCode, xmlNFe);
            }

            XmlNode node = lote.ImportNode(xmlNFe.DocumentElement, true);
            lote.DocumentElement.AppendChild(node);
            lote.PreserveWhitespace = true;
            xmlNFe.PreserveWhitespace = true;

            lote.Save(ObterCaminhoArquivo($"{enviNFe.IdLote}{SufixoLote}.xml"));
            xmlNFe.Save(ObterCaminhoArquivo($"{nf.InfNFe.Id.Substring(3)}{SufixoNFe}.xml"));

            return lote;
        }

        private ConsReciNFe ConsReciboNF(NFe nf, string numRec)
        {
            ConsReciNFe consReciNFe = new ConsReciNFe()
            {
                Versao = nf.InfNFe.Versao,
                NRec = numRec,
                TpAmb = nf.InfNFe.Ide.TpAmb
            };

            consReciNFe.Salvar(ObterCaminhoArquivo($"{nf.InfNFe.Id.Substring(3)}{SufixoPedRec}.xml"));

            return consReciNFe;
        }

        private bool RetornoRecibo(RetEnviNFe retEnviNFe)
        {
            retEnviNFe.Salvar(ObterCaminhoArquivo($"{retEnviNFe.InfRec.NRec}{SufixoProRec}.xml"));

            if (retEnviNFe.CStat == "103")
            {
                NumRecibo = retEnviNFe.InfRec.NRec;
                Mensagem = $"{retEnviNFe.CStat}-{retEnviNFe.XMotivo}";
                return true;
            }

            Erro = $"{retEnviNFe.CStat}-{retEnviNFe.XMotivo}";
            return false;
        }

        private bool RetornoConsultaRecibo(NFe nfe, RetConsReciNFe retConsReciNFe, string caminhoNF, out bool tentarNovamente)
        {
            retConsReciNFe.Salvar(ObterCaminhoArquivo($"{NumRecibo}{SufixoProRec}.xml"));

            if(retConsReciNFe.CStat=="103" || retConsReciNFe.CStat == "105")
            {
                tentarNovamente = true;
                Mensagem = $"{retConsReciNFe.CStat}-{retConsReciNFe.XMotivo}";
                return false;
            }

            tentarNovamente = false;

            if (retConsReciNFe.CStat == "104")
            {
                if (retConsReciNFe.ProtNFe.InfProt.CStat == "100")
                {
                    GerarProcNFe(nfe, retConsReciNFe, caminhoNF);
                    Mensagem = $"{retConsReciNFe.ProtNFe.InfProt.CStat}-{retConsReciNFe.ProtNFe.InfProt.XMotivo}";
                    return true;
                }
                else
                {
                    Erro = $"{retConsReciNFe.ProtNFe.InfProt.CStat}-{retConsReciNFe.ProtNFe.InfProt.XMotivo}";
                    return false;
                }
            }
            else
            {
                Erro = $"{retConsReciNFe.CStat}-{retConsReciNFe.XMotivo}";
                return false;
            }
        }

        private void GerarProcNFe(NFe nfe, RetConsReciNFe retConsReciNFe, string caminhoNF)
        {
            XmlDocument xmlNFe = new XmlDocument();
            ProcNFe procNFe = new ProcNFe();

            procNFe.Versao = retConsReciNFe.Versao;
            procNFe.ProtNFe = retConsReciNFe.ProtNFe;

            xmlNFe.Load(caminhoNF);
            XmlDocument xmlProc = procNFe.ToXmlDocument();

            XmlNode node = xmlProc.ImportNode(xmlNFe.DocumentElement, true);
            xmlProc.DocumentElement.PrependChild(node);
            xmlProc.PreserveWhitespace = true;

            xmlProc.Save(ObterCaminhoArquivo($"{nfe.InfNFe.Id.Substring(3)}{SufixoProcNFe}.xml"));

            ProtocoloAutorizacao = retConsReciNFe.ProtNFe.InfProt.NProt;
            DataHoraAutorizacao = retConsReciNFe.ProtNFe.InfProt.DhRecbto;
        }

        private bool ValidarDocumentoFiscal(string caminhoXML)
        {
            ValidarSchemaDocFiscal.SetarSquemaXSD(CaminhoSchemaXSD);
            if (ValidarSchemaDocFiscal.ValidarDocumentoXML(caminhoXML))
            {
                return true;
            }
            else
            {
                Erro = ValidarSchemaDocFiscal.Erros;
                return false;
            }
        }

        public void LiberarRecurso()
        {
            AssinaturaDigital = new AssinaturaDigital();
            Certificado = new CertificadoDigital();
            ValidarSchemaDocFiscal = new ValidarDocumentoFiscal();
            NumRecibo = "";
            ProtocoloAutorizacao = "";
            IDToken = "";
            CSC = "";
            Erro = "";
            Mensagem = "";
        }
    }
}
