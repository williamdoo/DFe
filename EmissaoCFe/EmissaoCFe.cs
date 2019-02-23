using Aplicacao;
using SchemaCFe.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissaoCFe
{
    public class EmissaoCFe
    {
        Prod produto;
        Imposto imposto;
        MP mr;
        private CFe CFe { get; set; }

        public void Novo()
        {
            CFe = new CFe()
            {
                InfCFe = new InfCFe()
                {
                    Ide = new Ide(),
                    Emit = new Emit(),
                    Dest = new Dest(),
                    Total = new Total(),
                    Pgto = new Pgto()
                }
            };
        }

        private void AdicionarEntrega()
        {
            if (CFe.InfCFe.Entrega == null)
            {
                CFe.InfCFe.Entrega = new Entrega();
            }
        }

        private void AdicionarDetProdutoServico()
        {
            if (CFe.InfCFe.Det == null)
            {
                CFe.InfCFe.Det = new List<Det>();
            }
        }

        private void AdicionarFiscoProdutoServico()
        {
            if (produto.ObsFiscoDet == null)
            {
                produto.ObsFiscoDet = new ObsFiscoDet();
            }
        }

        private void AdicionarDescAcres()
        {
            if (CFe.InfCFe.Total.DescAcrEntr == null)
            {
                CFe.InfCFe.Total.DescAcrEntr = new DescAcrEntr();
            }
        }

        private void AdicionarMP()
        {
            if (CFe.InfCFe.Pgto.MP == null)
            {
                CFe.InfCFe.Pgto.MP = new List<MP>();
            }
        }

        public void SetarInformacoes(string campo, string valor)
        {
            CFe.InfCFe.SetarValor(campo, valor);
        }

        public void SetarInformacoesIde(string campo, string valor)
        {
            CFe.InfCFe.Ide.SetarValor(campo, valor);
        }

        public void SetarInformacoesEmit(string campo, string valor)
        {
            CFe.InfCFe.Emit.SetarValor(campo, valor);
        }

        public void SetarInformacoesDest(string campo, string valor)
        {
            CFe.InfCFe.Dest.SetarValor(campo, valor);
        }

        public void SetarDestinatario(string campo, string valor)
        {
            CFe.InfCFe.Dest.SetarValor(campo, valor);
        }

        public void SetarInformacoesEntrega(string campo, string valor)
        {
            AdicionarEntrega();

            CFe.InfCFe.Entrega.SetarValor(campo, valor);
        }

        public void AdicionarProdutoServico()
        {
            AdicionarDetProdutoServico();
            produto = new Prod();
            imposto = new Imposto();
            Det det = new Det()
            {
                NItem = (CFe.InfCFe.Det.Count + 1).ToString(),
                Prod = produto,
                Imposto = imposto
            };

            CFe.InfCFe.Det.Add(det);
        }


        public void SetarProdutoServico(string campo, string valor)
        {
            produto.SetarValor(campo, valor);
        }

        public void SetarFiscoProdutoServico(string campo, string valor)
        {
            AdicionarFiscoProdutoServico();

            produto.ObsFiscoDet.SetarValor(campo, valor);
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
                case "ICMS40":
                    if (imposto.ICMS.ICMS40 == null)
                    {
                        imposto.ICMS.ICMS40 = new ICMS40();
                    }

                    imposto.ICMS.ICMS40.SetarValor(campo, valor);
                    break;
                case "ICMSSN102":
                    if (imposto.ICMS.ICMSSN102 == null)
                    {
                        imposto.ICMS.ICMSSN102 = new ICMSSN102();
                    }

                    imposto.ICMS.ICMSSN102.SetarValor(campo, valor);
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

        public void SetarPISProdutoServico(string pisTrib, string campo, string valor)
        {
            if (imposto.PIS == null)
            {
                imposto.PIS = new PIS();
            }

            switch (pisTrib)
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
                case "PISSN":
                    if (imposto.PIS.PISSN == null)
                    {
                        imposto.PIS.PISSN = new PISSN();
                    }

                    imposto.PIS.PISSN.SetarValor(campo, valor);
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

        public void SetarCOFINSProdutoServico(string cofinsTrib, string campo, string valor)
        {
            if (imposto.COFINS == null)
            {
                imposto.COFINS = new COFINS();
            }

            switch (cofinsTrib)
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
                case "PISSN":
                    if (imposto.COFINS.COFINSSN == null)
                    {
                        imposto.COFINS.COFINSSN = new COFINSSN();
                    }

                    imposto.COFINS.COFINSSN.SetarValor(campo, valor);
                    break;
                case "PISOutr":
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

        public void SetarISSQNProdutoServico(string campo, string valor)
        {
            if (imposto.ISSQN == null)
            {
                imposto.ISSQN = new ISSQN();
            }

            imposto.ISSQN.SetarValor(campo, valor);
        }

        public void SetarDescontoAcrescimo(string campo, string valor)
        {
            AdicionarDescAcres();
            CFe.InfCFe.Total.DescAcrEntr.SetarValor(campo, valor);
        }

        public void SetarLei12741(string campo, string valor)
        {
            CFe.InfCFe.Total.SetarValor(campo, valor);
        }

        public void AdicionarMeiosPagamento()
        {
            mr = new MP();
            AdicionarMP();
            CFe.InfCFe.Pgto.MP.Add(mr);
        }

        public void SetarMeiosPagamento(string campo, string valor)
        {
            mr.SetarValor(campo, valor);
        }

        public void SetarInfAdic(string campo, string valor)
        {
            if (CFe.InfCFe.InfAdic == null)
            {
                CFe.InfCFe.InfAdic = new InfAdic();
            }

            CFe.InfCFe.InfAdic.SetarValor(campo, valor);
        }

        public void SalvarCFe(string nome)
        {
            CFe.Salvar(nome, false);
        }
    }
}
