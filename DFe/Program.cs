using Aplicacao;
using Danfe;
using EmissaoNF;
using SchemaNF.Lote;
using SchemaNF.NF;
using SchemaNF.ProcNF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsdl.EnderecoWS;

namespace DFe
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string opcao = "";
                do
                {
                    Console.WriteLine("Escolha a opção");
                    Console.WriteLine("1-NFC-e");
                    Console.WriteLine("2-CF-e SAT");
                    opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            MenuNFCe();
                            break;

                        case "2":
                            GerarCFe();
                            break;
                    }
                } while (opcao != "sair");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n\n" + ex.StackTrace);
                Console.ReadKey();
            }
        }

        private static void MenuNFCe()
        {
            string opcao = "";

            do
            {
                Console.WriteLine("Opção para NFC-e");
                Console.WriteLine("1-Teste Status NFC-e");
                Console.WriteLine("2-Teste Schema NFC-e");
                Console.WriteLine("3-Teste envio NFC-e");
                Console.WriteLine("4-Teste Gerar Danfe NF-e");
                //opcao = Console.ReadLine();
                opcao = "4";
                switch (opcao)
                {
                    case "1":
                        TestarStatusNFCe();
                        break;

                    case "2":
                        TestarEsquemaNFCe();
                        break;

                    case "3":
                        TestarEnvioNFCe();
                        break;

                    case "4":
                        TestarGerarDanfeNFe();
                        Console.WriteLine("Danfe gerado");
                        Console.ReadKey();
                        break;
                }

            } while (opcao != "sair");
        }

        private static void GerarCFe()
        {
            EmissaoCFe.EmissaoCFe cfe = new EmissaoCFe.EmissaoCFe();

            cfe.Novo();

            cfe.SetarInformacoes("versaoDadosEnt", "0.06");

            cfe.SetarInformacoesIde("CNPJ", "11111111111111");
            cfe.SetarInformacoesIde("signAC", "qw1e9a81sd9819sad859v19z5cx1v98z1gdf989wa419e8r4afqw9e8f19sdv98zxc1v98a1we98t1a9we8r49aw8d41v981zxc98198sd1f989qw498er4qw9e8r4f9s8d1v98z9as1er9w1ef98as1d9f51a9sd5f19wa5e1r95as1df951sd95v1zs65v13as1df65wa1e9r8f51d51c96d51xc9581s9d81fa9w81er9q8919q19a81s9851a9w85e1q95w19er8r1q9fd51z695x1c95sd1f91x9a5se01f95as1df98as1df99we1a9f51zs9df51a9we81w==");
            cfe.SetarInformacoesIde("numeroCaixa", "001");

            cfe.SetarInformacoesEmit("CNPJ", "11111111111111");
            cfe.SetarInformacoesEmit("IE", "111111111111");
            cfe.SetarInformacoesEmit("cRegTribISSQN", "1");
            cfe.SetarInformacoesEmit("indRatISSQN", "N");

            cfe.SetarInformacoesDest("CPF", "82006628871");
            cfe.SetarInformacoesDest("xNome", "Nome deo Cliente");

            cfe.AdicionarProdutoServico();
            cfe.SetarProdutoServico("cProd", "102030");
            cfe.SetarProdutoServico("xProd", "Produto Teste");
            cfe.SetarProdutoServico("NCM", "18069000");
            cfe.SetarProdutoServico("CEST", "1235263");
            cfe.SetarProdutoServico("CFOP", "5102");
            cfe.SetarProdutoServico("uCom", "1.000");
            cfe.SetarProdutoServico("qCom", "1.0000");
            cfe.SetarProdutoServico("vUnCom", "2.500");
            cfe.SetarProdutoServico("indRegra", "A");

            cfe.SetarICMSProdutoServico("ICMS00", "Orig", "0");
            cfe.SetarICMSProdutoServico("ICMS00", "CST", "00");
            cfe.SetarICMSProdutoServico("ICMS00", "pICMS", "7.00");

            cfe.SetarPISProdutoServico("PISNT", "CST", "07");

            cfe.SetarCOFINSProdutoServico("COFINSNT", "CST", "07");

            cfe.AdicionarMeiosPagamento();
            cfe.SetarMeiosPagamento("cMP", "01");
            cfe.SetarMeiosPagamento("vMP", "2.50");

            cfe.SalvarCFe(@"C:\DadosCFe.xml");
        }
        
        private static void TestarStatusNFCe()
        {
            SistemaNF envio = new SistemaNF();

            envio.CarregarWebService(new WebServices()
            {
                NFCe = new List<EnderecoNFCe>() {
                    new EnderecoNFCe() {
                        Ambiente = Wsdl.EnderecoWS.EnderecoWS.Ambientes.Homologacao,
                        EnderecoQRCode ="https://www.homologacao.nfce.fazenda.sp.gov.br/NFCeConsultaPublica/",
                        Estado = Estados.UF.SP,
                        Servico = "NFeAutorizacao",
                        URLQRCode ="https://www.homologacao.nfce.fazenda.sp.gov.br/qrcode",
                        WebService = "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFeAutorizacao4.asmx"
                    },

                    new EnderecoNFCe() {
                        Ambiente = Wsdl.EnderecoWS.EnderecoWS.Ambientes.Homologacao,
                        EnderecoQRCode ="https://www.homologacao.nfce.fazenda.sp.gov.br/NFCeConsultaPublica/",
                        Estado = Estados.UF.SP,
                        Servico = "NFeRetAutorizacao",
                        URLQRCode ="https://www.homologacao.nfce.fazenda.sp.gov.br/qrcode",
                        WebService = "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFeRetAutorizacao4.asmx"
                    },

                    new EnderecoNFCe() {
                        Ambiente = Wsdl.EnderecoWS.EnderecoWS.Ambientes.Homologacao,
                        EnderecoQRCode ="https://www.homologacao.nfce.fazenda.sp.gov.br/NFCeConsultaPublica/",
                        Estado = Estados.UF.SP,
                        Servico = "NFeStatusServico",
                        URLQRCode ="https://www.homologacao.nfce.fazenda.sp.gov.br/qrcode",
                        WebService = "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFeStatusServico4.asmx"
                    }
                }
            });


            if (envio.StatusNFCe(EnderecoWS.Ambientes.Homologacao, Estados.UF.SP, "4.00"))
            {
                Console.WriteLine(envio.Mensagem);
            }
            else
            {
                Console.WriteLine(envio.Erro);
            }
        }

        private static void TestarEsquemaNFCe()
        {
            NFe nf = new NFe();

            nf.InfNFe = new infNFe()
            {
                Versao = "4.00",
                Id = "NFe35080599999090910270550010000000015180051273",
                Ide = new Ide()
                {
                    CUF = "35",
                    CNF = "51800512",
                    NatOp = "Venda a vista",
                    Mod = "65",
                    Serie = "1",
                    NNF = "1",
                    DEmi = "2011-11-20",
                    DSaiEnt = "2008-05-06",
                    TpNF = "0",
                    CMunFG = "3550308",
                    TpImp = "1",
                    TpEmis = "1",
                    CDV = "3",
                    TpAmb = "2",
                    FinNFe = "1",
                    ProcEmi = "0",
                    VerProc = "1.0"
                },
                Emit = new Emit()
                {
                    CNPJ = "99999999000191",
                    XNome = "NFe",
                    XFant = "NFe",
                    EnderEmit = new SchemaNF.NF.Endereco()
                    {
                        XLgr = "Nome da loja LTDA",
                        Nro = "100",
                        XCpl = "Fundos",
                        XBairro = "Distrito Industrial",
                        CMun = "3502200",
                        XMun = "Angatuba",
                        UF = "SP",
                        CEP = "17100171",
                        CPais = "1058",
                        XPais = "Brasil",
                        Fone = "1733021717",
                    },
                    CRT = "3"
                },
                Dest = new Dest()
                {
                    CNPJ = "00000000000191",
                    XNome = "DISTRIBUIDORA DE AGUAS MINERAIS",
                    EnderDest = new SchemaNF.NF.Endereco()
                    {
                        XLgr = "V DAS FONTES",
                        Nro = "1777",
                        XCpl = "10 Andar",
                        XBairro = "Pq Fontes",
                        CMun = "5030801",
                        XMun = "Sao Paulo",
                        UF = "SP",
                        CEP = "13950000",
                        CPais = "1058",
                        XPais = "Brasil",
                        Fone = "1932011234"
                    },
                    IE = ""
                },
                Retirada = new EnderCom()
                {
                    CNPJ = "99171171000194",
                    XLgr = "AV PAULISTA",
                    Nro = "12345",
                    XCpl = "TERREO",
                    XBairro = "CERQUEIRA CESAR",
                    CMun = "3550308",
                    XMun = "SAO PAULO",
                    UF = "SP"
                },
                Entrega = new EnderCom()
                {
                    CNPJ = "99299299000194",
                    XLgr = "AV FARIA LIMA",
                    Nro = "1500",
                    XCpl = "15 ANDAR",
                    XBairro = "PINHEIROS",
                    CMun = "3550308",
                    XMun = "SAO PAULO",
                    UF = "SP"
                },
                Det = new List<Det>(),
                Total = new Total()
                {
                    ICMSTot = new ICMSTot()
                    {
                        VBC = "20000000.00",
                        VICMS = "18.00",
                        VBCST = "0",
                        VST = "0",
                        VProd = "20000000.00",
                        VFrete = "0",
                        VSeg = "0",
                        VDesc = "0",
                        VII = "0",
                        VIPI = "0",
                        VPIS = "130000.00",
                        VCOFINS = "400000.00",
                        VOutro = "0",
                        VNF = "20000000.00"
                    }
                },
                Transp = new Transp()
                {
                    ModFrete = "0",
                    Transporta = new Transporta()
                    {
                        CNPJ = "99171171000191",
                        XNome = "Distribuidora de Bebidas Fazenda de SP Ltda.",
                        IE = "171999999119",
                        XEnder = "Rua Central 100 - Fundos - Distrito Industrial",
                        XMun = "SAO PAULO",
                        UF = "SP",
                    },
                    VeicTransp = new VeicTransp()
                    {
                        Placa = "BXI1717",
                        UF = "SP",
                        RNTC = "123456789"
                    },
                    Reboque = new Reboque()
                    {
                        Placa = "BXI1818",
                        UF = "SP",
                        RNTC = "123456789"
                    },
                    Vol = new List<Vol>()
                },
                InfAdic = new InfAdic()
                {
                    InfAdFisco = "Nota Fiscal de exemplo NF-eletronica.com"
                }
            };

            nf.InfNFe.Det.Add(new Det()
            {
                NItem = "1",
                Prod = new Prod()
                {
                    CProd = "00001",
                    CEAN = "",
                    XProd = "Agua Mineral",
                    NCM = "12002500",
                    CFOP = "5101",
                    UCom = "dz",
                    QCom = "1000000.0000",
                    VUnCom = "1",
                    VProd = "10000000.00",
                    CEANTrib = "",
                    UTrib = "un",
                    QTrib = "12000000.00",
                    VUnTrib = "1",
                    IndTot = "1"
                },
                Imposto = new Imposto()
                {
                    ICMS = new ICMS()
                    {
                        ICMS00 = new ICMS00()
                        {
                            orig = "0",
                            CST = "00",
                            ModBC = "0",
                            VBC = "10000000.00",
                            PICMS = "18.00",
                            VICMS = "1800000.00"
                        }
                    },
                    PIS = new PIS()
                    {
                        PISAliq = new PISAliq()
                        {
                            CST = "01",
                            VBC = "100000000.00",
                            PPIS = "0.65",
                            VPIS = "65000"
                        }
                    },
                    COFINS = new COFINS()
                    {
                        COFINSAliq = new COFINSAliq()
                        {
                            CST = "01",
                            VBC = "100000000.00",
                            PCOFINS = "2.00",
                            VCOFINS = "200000.00"
                        }
                    }
                }
            });

            nf.InfNFe.Det.Add(new Det()
            {
                NItem = "2",
                Prod = new Prod()
                {
                    CProd = "00002",
                    CEAN = "",
                    XProd = "Agua Mineral",
                    NCM = "12002500",
                    CFOP = "5101",
                    UCom = "pack",
                    QCom = "5000000.0000",
                    VUnCom = "2",
                    VProd = "10000000.00",
                    CEANTrib = "",
                    UTrib = "un",
                    QTrib = "3000000.00",
                    VUnTrib = "0.3333",
                    IndTot = "1"
                },
                Imposto = new Imposto()
                {
                    ICMS = new ICMS()
                    {
                        ICMS00 = new ICMS00()
                        {
                            orig = "0",
                            CST = "00",
                            ModBC = "0",
                            VBC = "10000000.00",
                            PICMS = "18.00",
                            VICMS = "1800000.00"
                        }
                    },
                    PIS = new PIS()
                    {
                        PISAliq = new PISAliq()
                        {
                            CST = "01",
                            VBC = "100000000.00",
                            PPIS = "0.65",
                            VPIS = "65000"
                        }
                    },
                    COFINS = new COFINS()
                    {
                        COFINSAliq = new COFINSAliq()
                        {
                            CST = "01",
                            VBC = "100000000.00",
                            PCOFINS = "2.00",
                            VCOFINS = "200000.00"
                        }
                    }
                }
            });

            nf.InfNFe.Transp.Vol.Add(new Vol()
            {
                QVol = "10000",
                Esp = "CAIXA",
                Marca = "LINDOYA",
                NVol = "500",
                PesoL = "1000000000.000",
                PesoB = "1200000000.000",
                Lacres = new List<Lacres>()
            });

            nf.InfNFe.Transp.Vol.First().Lacres.Add(new Lacres()
            {
                NLacre = "XYZ10231486"
            });

            nf.Salvar("35080599999090910270550010000000015180051273-NFe.xml", true);

            ProcNFe proc = new ProcNFe();

            proc.Versao = "4.00";
            proc.NFe = nf;
            proc.Salvar("ProcNFe35080599999090910270550010000000015180051273.xml", true);

            EnviNFe enviNFe = new EnviNFe()
            {
                IdLote = new Random(132546).Next().ToString(),
                Versao = "4.00"
            };
            enviNFe.NFe = new List<NFe>();
            enviNFe.NFe.Add(proc.NFe);

            enviNFe.Salvar(@"LoteNFe" + enviNFe.IdLote + ".xml", true);

            ValidarDocumentoFiscal validar = new ValidarDocumentoFiscal();
            validar.SetarSquemaXSD(@"");
            if (validar.ValidarDocumentoXML(@""))
            {
                Console.WriteLine("Validado com sucesso");
            }
            else
            {
                Console.WriteLine(validar.Erros);
            }
        }

        private static void TestarEnvioNFCe()
        {
            EmissaoNF.EmissaoNF nfce = new EmissaoNF.EmissaoNF();
            SistemaNF envio = new SistemaNF();
            envio.CarregarWebService(new WebServices()
            {
                NFCe = new List<EnderecoNFCe>() {
                    new EnderecoNFCe() {
                        Ambiente = Wsdl.EnderecoWS.EnderecoWS.Ambientes.Homologacao,
                        EnderecoQRCode ="https://www.homologacao.nfce.fazenda.sp.gov.br/NFCeConsultaPublica/",
                        Estado = Estados.UF.SP,
                        Servico = "NFeAutorizacao",
                        URLQRCode ="https://www.homologacao.nfce.fazenda.sp.gov.br/qrcode",
                        WebService = "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFeAutorizacao4.asmx"
                    },

                    new EnderecoNFCe() {
                        Ambiente = Wsdl.EnderecoWS.EnderecoWS.Ambientes.Homologacao,
                        EnderecoQRCode ="https://www.homologacao.nfce.fazenda.sp.gov.br/NFCeConsultaPublica/",
                        Estado = Estados.UF.SP,
                        Servico = "NFeRetAutorizacao",
                        URLQRCode ="https://www.homologacao.nfce.fazenda.sp.gov.br/qrcode",
                        WebService = "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFeRetAutorizacao4.asmx"
                    },

                    new EnderecoNFCe() {
                        Ambiente = Wsdl.EnderecoWS.EnderecoWS.Ambientes.Homologacao,
                        EnderecoQRCode ="https://www.homologacao.nfce.fazenda.sp.gov.br/NFCeConsultaPublica/",
                        Estado = Estados.UF.SP,
                        Servico = "NFeStatusServico",
                        URLQRCode ="https://www.homologacao.nfce.fazenda.sp.gov.br/qrcode",
                        WebService = "https://homologacao.nfce.fazenda.sp.gov.br/ws/NFeStatusServico4.asmx"
                    }
                }
            });

            envio.IDToken = "";
            envio.CSC = "";
            envio.CaminhoSchemaXSD = @"";

            nfce.Nova("4.00");
            nfce.SetarInformacoesIde("cUF", "35");
            nfce.SetarInformacoesIde("cNF", new Random().Next(10000000, 99999999).ToString());
            nfce.SetarInformacoesIde("natOp", "Venda de Mercadorias");
            nfce.SetarInformacoesIde("mod", "65");
            nfce.SetarInformacoesIde("serie", "88");
            nfce.SetarInformacoesIde("nNF", "1089");
            nfce.SetarInformacoesIde("dhEmi", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"));
            nfce.SetarInformacoesIde("tpNF", "1");
            nfce.SetarInformacoesIde("cMunFG", "3550308");
            nfce.SetarInformacoesIde("idDest", "1");
            nfce.SetarInformacoesIde("tpImp", "4");
            nfce.SetarInformacoesIde("tpEmis", "1");
            nfce.SetarInformacoesIde("tpAmb", "2");
            nfce.SetarInformacoesIde("finNFe", "1");
            nfce.SetarInformacoesIde("indFinal", "1");
            nfce.SetarInformacoesIde("indPres", "1");
            nfce.SetarInformacoesIde("procEmi", "0");
            nfce.SetarInformacoesIde("verProc", "1.0");

            nfce.SetarInformacoesEmit("CNPJ", "99999999000191");
            nfce.SetarInformacoesEmit("xNome", "Nome da loja LTDA");
            nfce.SetarInformacoesEmit("xFant", "Nome");
            nfce.SetarInformacoesEndEmit("xLgr", "Rua Qualquer uma");
            nfce.SetarInformacoesEndEmit("nro", "999");
            nfce.SetarInformacoesEndEmit("xCpl", "Loja");
            nfce.SetarInformacoesEndEmit("xBairro", "Bairro");
            nfce.SetarInformacoesEndEmit("cMun", "3550308");
            nfce.SetarInformacoesEndEmit("xMun", "São Paulo");
            nfce.SetarInformacoesEndEmit("UF", "SP");
            nfce.SetarInformacoesEndEmit("CEP", "08899012");
            nfce.SetarInformacoesEndEmit("cPais", "1058");
            nfce.SetarInformacoesEndEmit("xPais", "BRASIL");
            nfce.SetarInformacoesEndEmit("fone", "1112345678");
            nfce.SetarInformacoesEmit("IE", "111111111111");
            nfce.SetarInformacoesEmit("IM", "99999999");
            nfce.SetarInformacoesEmit("CNAE", "12345678");
            nfce.SetarInformacoesEmit("CRT", "3");

            nfce.SetarInformacoesDest("CPF", "34355533085");
            nfce.SetarInformacoesDest("xNome", "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL");
            nfce.SetarInformacoesDest("indIEDest", "9");

            nfce.AdicionarProdutoServico();
            nfce.SetarProdutoServico("cProd", "1000000");
            nfce.SetarProdutoServico("cEAN", "SEM GTIN");
            nfce.SetarProdutoServico("xProd", "Produto teste");
            nfce.SetarProdutoServico("NCM", "18069000");
            nfce.SetarProdutoServico("CEST", "1300402");
            nfce.SetarProdutoServico("CFOP", "5405");
            nfce.SetarProdutoServico("uCom", "UN");
            nfce.SetarProdutoServico("qCom", "2.000");
            nfce.SetarProdutoServico("vUnCom", "10.00");
            nfce.SetarProdutoServico("vProd", "20.00");
            nfce.SetarProdutoServico("cEANTrib", "SEM GTIN");
            nfce.SetarProdutoServico("uTrib", "UN");
            nfce.SetarProdutoServico("qTrib", "2.000");
            nfce.SetarProdutoServico("vUnTrib", "10.00");
            nfce.SetarProdutoServico("indTot", "1");

            nfce.SetarICMSProdutoServico("ICMS60", "orig", "0");
            nfce.SetarICMSProdutoServico("ICMS60", "CST", "60");
            nfce.SetarICMSProdutoServico("ICMS60", "vBCSTRet", "0.00");
            nfce.SetarICMSProdutoServico("ICMS60", "pST", "2.0000");
            nfce.SetarICMSProdutoServico("ICMS60", "vICMSSTRet", "0.00");
            nfce.SetarICMSProdutoServico("ICMS60", "vBCFCPSTRet", "0.00");
            nfce.SetarICMSProdutoServico("ICMS60", "pFCPSTRet", "2.00");
            nfce.SetarICMSProdutoServico("ICMS60", "vFCPSTRet", "0.00");

            nfce.SetarPISProdutoServico("PISAliq", "CST", "01");
            nfce.SetarPISProdutoServico("PISAliq", "vBC", "2.50");
            nfce.SetarPISProdutoServico("PISAliq", "pPIS", "1.6500");
            nfce.SetarPISProdutoServico("PISAliq", "vPIS", "0.04");

            nfce.SetarPISProdutoServico("COFINSAliq", "CST", "01");
            nfce.SetarPISProdutoServico("COFINSAliq", "vBC", "2.50");
            nfce.SetarPISProdutoServico("COFINSAliq", "pPIS", "7.6000");
            nfce.SetarPISProdutoServico("COFINSAliq", "vPIS", "0.19");

            nfce.SetarInformacoesTotal("vBC", "0.00");
            nfce.SetarInformacoesTotal("vICMS", "0.00");
            nfce.SetarInformacoesTotal("vICMSDeson", "0.00");
            nfce.SetarInformacoesTotal("vFCP", "0.00");
            nfce.SetarInformacoesTotal("vBCST", "0.00");
            nfce.SetarInformacoesTotal("vST", "0.00");
            nfce.SetarInformacoesTotal("vFCPST", "0.00");
            nfce.SetarInformacoesTotal("vFCPSTRet", "0.00");
            nfce.SetarInformacoesTotal("vProd", "15.00");
            nfce.SetarInformacoesTotal("vFrete", "0.00");
            nfce.SetarInformacoesTotal("vSeg", "0.00");
            nfce.SetarInformacoesTotal("vDesc", "0.00");
            nfce.SetarInformacoesTotal("vII", "0.00");
            nfce.SetarInformacoesTotal("vIPI", "0.00");
            nfce.SetarInformacoesTotal("vIPIDevol", "0.00");
            nfce.SetarInformacoesTotal("vPIS", "0.04");
            nfce.SetarInformacoesTotal("vCOFINS", "0.19");
            nfce.SetarInformacoesTotal("vOutro", "0.00");
            nfce.SetarInformacoesTotal("vNF", "15.00");

            nfce.AdicionarFormaPagamento();
            nfce.SetarDetalhePagamento("tPag", "01");
            nfce.SetarDetalhePagamento("vPag", "15.00");

            nfce.SetarInformacoesTransp("transp", "modFrete", "9");

            if (envio.EnviarNFCe(nfce.NFe, new Random(1325).Next().ToString()))
            {
                string caminhoNFe = envio.ObterCaminhoArquivo($"{envio.ChaveNFe}{envio.SufixoNFe}.xml");
                Console.WriteLine(envio.Mensagem);

                if (envio.ConsultaSituacaoAtualNFCe(caminhoNFe, envio.NumRecibo))
                {
                    Console.WriteLine(envio.Mensagem);
                }
                else
                {
                    Console.WriteLine(envio.Erro);
                }
            }
            else
            {
                Console.WriteLine(envio.Erro);
            }

            envio.LiberarRecurso();
        }

        private static void TestarGerarDanfeNFe()
        {
            GerarDanfe danfe = new GerarDanfe("35181100163903000193550010000020861051247599-Danfe", "NFe");
            danfe.CriarDanfe(@"35181100163903000193550010000020861051247599-procNFe.xml");
        }
    }
}
