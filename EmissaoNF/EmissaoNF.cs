using Aplicacao;
using SchemaNF.NF;
using System.Collections.Generic;

namespace EmissaoNF
{
    public class EmissaoNF
    {
        Prod produto;
        Imposto imposto;
        DetPag detPag;
        Endereco enderEmit;
        public NFe NFe { get; private set; }
        public void Nova(string versao)
        {
            NFe = new NFe()
            {
                InfNFe = new infNFe()
                {
                    Versao = versao,
                    Ide = new Ide(),
                    Emit = new Emit(),
                    Det = new List<Det>(),
                    Total = new Total()
                    {
                        ICMSTot = new ICMSTot()
                    },
                    Pag = new Pag(),
                    Transp = new Transp()
                }
            };
        }

        public void SetarInformacoesIde(string campo, string valor)
        {
            NFe.InfNFe.Ide.SetarValor(campo, valor);
        }

        public void SetarInformacoesNFRef(string refNFe)
        {
            if (NFe.InfNFe.Ide.NFref == null)
            {
                NFe.InfNFe.Ide.NFref = new List<NFref>();
            }

            NFe.InfNFe.Ide.NFref.Add(new NFref() { RefNFe = refNFe });
        }

        public void SetarInformacoesEmit(string campo, string valor)
        {
            NFe.InfNFe.Emit.SetarValor(campo, valor);
        }

        public void SetarInformacoesEndEmit(string campo, string valor)
        {
            if (enderEmit == null)
            {
                enderEmit = new Endereco();
                NFe.InfNFe.Emit.EnderEmit = enderEmit;
            }

            enderEmit.SetarValor(campo, valor);
        }

        public void SetarInformacoesDest(string campo, string valor)
        {
            if (NFe.InfNFe.Dest == null)
            {
                NFe.InfNFe.Dest = new Dest();
            }
            NFe.InfNFe.Dest.SetarValor(campo, valor);
        }

        public void SetarInformacoesEndDest(string campo, string valor)
        {
            if (NFe.InfNFe.Dest.EnderDest == null)
            {
                NFe.InfNFe.Dest.EnderDest = new Endereco();
            }

            NFe.InfNFe.Dest.EnderDest.SetarValor(campo, valor);
        }

        public void AdicionarProdutoServico()
        {
            produto = new Prod();
            imposto = new Imposto();
            Det det = new Det()
            {
                NItem = (NFe.InfNFe.Det.Count + 1).ToString(),
                Prod = produto,
                Imposto = imposto
            };

            NFe.InfNFe.Det.Add(det);
        }

        public void SetarProdutoServico(string campo, string valor)
        {
            if (campo == "xProd" && NFe.InfNFe.Det.Count == 1 && NFe.InfNFe.Ide.TpAmb=="2")
            {
                valor = "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
            }

            produto.SetarValor(campo, valor);
        }

        public void SetarICMSProdutoServico(string icmsTrib, string campo, string valor)
        {
            if (imposto.ICMS == null)
            {
                imposto.ICMS = new ICMS();
            }

            switch (icmsTrib)
            {
                case "ICMS00":
                    if (imposto.ICMS.ICMS00 == null)
                    {
                        imposto.ICMS.ICMS00 = new ICMS00();
                    }

                    imposto.ICMS.ICMS00.SetarValor(campo, valor);
                    break;
                case "ICMS10":
                    if (imposto.ICMS.ICMS10 == null)
                    {
                        imposto.ICMS.ICMS10 = new ICMS10();
                    }

                    imposto.ICMS.ICMS10.SetarValor(campo, valor);
                    break;
                case "ICMS20":
                    if (imposto.ICMS.ICMS20 == null)
                    {
                        imposto.ICMS.ICMS20 = new ICMS20();
                    }

                    imposto.ICMS.ICMS20.SetarValor(campo, valor);
                    break;
                case "ICMS30":
                    if (imposto.ICMS.ICMS30 == null)
                    {
                        imposto.ICMS.ICMS30 = new ICMS30();
                    }

                    imposto.ICMS.ICMS30.SetarValor(campo, valor);
                    break;
                case "ICMS40":
                    if (imposto.ICMS.ICMS40 == null)
                    {
                        imposto.ICMS.ICMS40 = new ICMS40();
                    }

                    imposto.ICMS.ICMS40.SetarValor(campo, valor);
                    break;
                case "ICMS51":
                    if (imposto.ICMS.ICMS51 == null)
                    {
                        imposto.ICMS.ICMS51 = new ICMS51();
                    }

                    imposto.ICMS.ICMS51.SetarValor(campo, valor);
                    break;
                case "ICMS60":
                    if (imposto.ICMS.ICMS60 == null)
                    {
                        imposto.ICMS.ICMS60 = new ICMS60();
                    }

                    imposto.ICMS.ICMS60.SetarValor(campo, valor);
                    break;
                case "ICMS70":
                    if (imposto.ICMS.ICMS70 == null)
                    {
                        imposto.ICMS.ICMS70 = new ICMS70();
                    }

                    imposto.ICMS.ICMS70.SetarValor(campo, valor);
                    break;
                case "ICMS90":
                    if (imposto.ICMS.ICMS90 == null)
                    {
                        imposto.ICMS.ICMS90 = new ICMS90();
                    }

                    imposto.ICMS.ICMS90.SetarValor(campo, valor);
                    break;
                case "ICMSPart":
                    if (imposto.ICMS.ICMSPart == null)
                    {
                        imposto.ICMS.ICMSPart = new ICMSPart();
                    }

                    imposto.ICMS.ICMSPart.SetarValor(campo, valor);
                    break;
                case "ICMSST":
                    if (imposto.ICMS.ICMSST == null)
                    {
                        imposto.ICMS.ICMSST = new ICMSST();
                    }

                    imposto.ICMS.ICMSST.SetarValor(campo, valor);
                    break;
                case "ICMSSN101":
                    if (imposto.ICMS.ICMSSN101 == null)
                    {
                        imposto.ICMS.ICMSSN101 = new ICMSSN101();
                    }

                    imposto.ICMS.ICMSSN101.SetarValor(campo, valor);
                    break;
                case "ICMSSN102":
                    if (imposto.ICMS.ICMSSN102 == null)
                    {
                        imposto.ICMS.ICMSSN102 = new ICMSSN102();
                    }

                    imposto.ICMS.ICMSSN102.SetarValor(campo, valor);
                    break;
                case "ICMSSN201":
                    if (imposto.ICMS.ICMSSN201 == null)
                    {
                        imposto.ICMS.ICMSSN201 = new ICMSSN201();
                    }

                    imposto.ICMS.ICMSSN201.SetarValor(campo, valor);
                    break;
                case "ICMSSN202":
                    if (imposto.ICMS.ICMSSN202 == null)
                    {
                        imposto.ICMS.ICMSSN202 = new ICMSSN202();
                    }

                    imposto.ICMS.ICMSSN202.SetarValor(campo, valor);
                    break;
                case "ICMSSN500":
                    if (imposto.ICMS.ICMSSN500 == null)
                    {
                        imposto.ICMS.ICMSSN500 = new ICMSSN500();
                    }

                    imposto.ICMS.ICMSSN500.SetarValor(campo, valor);
                    break;
                case "ICMSSN900":
                    if (imposto.ICMS.ICMSSN900 == null)
                    {
                        imposto.ICMS.ICMSSN900 = new ICMSSN900();
                    }

                    imposto.ICMS.ICMSSN900.SetarValor(campo, valor);
                    break;
            }
        }

        public void SetarInformacoesIPI(string campo, string valor)
        {
            if (imposto.IPI == null)
            {
                imposto.IPI = new IPI();
            }

            imposto.IPI.SetarValor(campo, valor);
        }

        public void SetarIPIProdutoServico(string grupoIpi, string campo, string valor)
        {
            if (imposto.IPI == null)
            {
                imposto.IPI = new IPI();
            }

            switch (grupoIpi)
            {
                case "IPITrib":

                    if (imposto.IPI.IPITrib == null)
                    {
                        imposto.IPI.IPITrib = new IPITrib();
                    }

                    imposto.IPI.IPITrib.SetarValor(campo, valor);
                    break;
                case "IPINT":

                    if (imposto.IPI.IPINT == null)
                    {
                        imposto.IPI.IPINT = new IPINT();
                    }

                    imposto.IPI.IPINT.SetarValor(campo, valor);
                    break;
            }
        }

        public void SetarPISProdutoServico(string grupoPis, string campo, string valor)
        {
            if (imposto.PIS == null)
            {
                imposto.PIS = new PIS();
            }

            switch (grupoPis)
            {
                case "PISAliq":

                    if (imposto.PIS.PISAliq == null)
                    {
                        imposto.PIS.PISAliq = new PISAliq();
                    }

                    imposto.PIS.PISAliq.SetarValor(campo, valor);
                    break;
                case "PISQtde":

                    if (imposto.PIS.PISQtde == null)
                    {
                        imposto.PIS.PISQtde = new PISQtde();
                    }

                    imposto.PIS.PISQtde.SetarValor(campo, valor);
                    break;
                case "PISNT":

                    if (imposto.PIS.PISNT == null)
                    {
                        imposto.PIS.PISNT = new PISNT();
                    }

                    imposto.PIS.PISNT.SetarValor(campo, valor);
                    break;
                case "PISOutr":

                    if (imposto.PIS.PISOutr == null)
                    {
                        imposto.PIS.PISOutr = new PISOutr();
                    }

                    imposto.PIS.PISOutr.SetarValor(campo, valor);
                    break;
                case "PISST":

                    if (imposto.PIS.PISST == null)
                    {
                        imposto.PIS.PISST = new PISST();
                    }

                    imposto.PIS.PISST.SetarValor(campo, valor);
                    break;
            }
        }

        public void SetarCOFINSProdutoServico(string grupoCofins, string campo, string valor)
        {
            if (imposto.COFINS == null)
            {
                imposto.COFINS = new COFINS();
            }

            switch (grupoCofins)
            {
                case "COFINSAliq":

                    if (imposto.COFINS.COFINSAliq == null)
                    {
                        imposto.COFINS.COFINSAliq = new COFINSAliq();
                    }

                    imposto.COFINS.COFINSAliq.SetarValor(campo, valor);
                    break;
                case "COFINSQtde":

                    if (imposto.COFINS.COFINSQtde == null)
                    {
                        imposto.COFINS.COFINSQtde = new COFINSQtde();
                    }

                    imposto.COFINS.COFINSQtde.SetarValor(campo, valor);
                    break;
                case "COFINSNT":

                    if (imposto.COFINS.COFINSNT == null)
                    {
                        imposto.COFINS.COFINSNT = new COFINSNT();
                    }

                    imposto.COFINS.COFINSNT.SetarValor(campo, valor);
                    break;
                case "COFINSOutr":

                    if (imposto.COFINS.COFINSOutr == null)
                    {
                        imposto.COFINS.COFINSOutr = new COFINSOutr();
                    }

                    imposto.COFINS.COFINSOutr.SetarValor(campo, valor);
                    break;
                case "PISST":

                    if (imposto.COFINS.COFINSST == null)
                    {
                        imposto.COFINS.COFINSST = new COFINSST();
                    }

                    imposto.COFINS.COFINSST.SetarValor(campo, valor);
                    break;
            }
        }

        public void SetarInformacoesTotal(string campo, string valor)
        {
            NFe.InfNFe.Total.ICMSTot.SetarValor(campo, valor);
        }

        public void AdicionarFormaPagamento()
        {
            if (NFe.InfNFe.Pag.DetPag == null)
            {
                NFe.InfNFe.Pag.DetPag = new List<DetPag>();
            }

            detPag = new DetPag();
            NFe.InfNFe.Pag.DetPag.Add(detPag);
        }

        public void SetarDetalhePagamento(string campo, string valor)
        {
            detPag.SetarValor(campo, valor);
        }

        public void SetarTroco(string campo, string valor)
        {
            NFe.InfNFe.Pag.SetarValor(campo, valor);
        }

        public void SetarInformacoesTransp(string grupoTransp, string campo, string valor)
        {
            switch (grupoTransp)
            {
                case "transp":
                    NFe.InfNFe.Transp.SetarValor(campo, valor);
                    break;
                case "transporta":
                    if(NFe.InfNFe.Transp.Transporta == null)
                    {
                        NFe.InfNFe.Transp.Transporta = new Transporta();
                    }
                    NFe.InfNFe.Transp.Transporta.SetarValor(campo, valor);
                    break;
                case "retTransp":
                    if(NFe.InfNFe.Transp.RetTransp == null)
                    {
                        NFe.InfNFe.Transp.RetTransp = new RetTransp();
                    }
                    NFe.InfNFe.Transp.RetTransp.SetarValor(campo, valor);
                    break;
                case "veicTransp":
                    if (NFe.InfNFe.Transp.VeicTransp == null)
                    {
                        NFe.InfNFe.Transp.VeicTransp = new VeicTransp();
                    }
                    NFe.InfNFe.Transp.VeicTransp.SetarValor(campo, valor);
                    break;
                case "reboque":
                    if (NFe.InfNFe.Transp.Reboque == null)
                    {
                        NFe.InfNFe.Transp.Reboque = new Reboque();
                    }
                    NFe.InfNFe.Transp.Reboque.SetarValor(campo, valor);
                    break;
                case "vol":
                    if (NFe.InfNFe.Transp.Vol == null)
                    {
                        NFe.InfNFe.Transp.Vol = new List<Vol>();
                    }
                    Vol vol = new Vol();
                    vol.SetarValor(campo, valor);
                    NFe.InfNFe.Transp.Vol.Add(vol);
                    break;
            }
            
        }

        public void SetarInformacoesInfAdic(string campo, string valor)
        {
            NFe.InfNFe.InfAdic.SetarValor(campo, valor);
        }
    }
}
