using Danfe.Componente;
using Danfe.Layout;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WVFramework.Converters;
using WVFramework.Formats;

namespace Danfe
{
    public class GerarDanfe
    {
        PDF docPDF;
        XmlDocument docXml;
        public GerarDanfe(string namePdf, string path)
        {
            docPDF = new PDF(Path.Combine(path, namePdf));
        }

        public void CriarDanfe(string pathXml)
        {
            docXml = new XmlDocument();
            docXml.Load(pathXml);

            docPDF.Open();
            GerarCanhoto();
            GerarCabecalho();
            GerarDestinatario();
            GerarFaturaDuplicata();
            GerarCalculoImposto();
            GerarTransportador();
            GerarDadosProdutoServico();
            GerarDadosAdicionais();
            docPDF.Close();
            docXml = null;
        }

        private void GerarCanhoto()
        {
            docPDF.AddField(null, new Text()
            {
                TextLabel = $"RECEBEMOS DE {GetInnerText(@"nfeProc\NFe\infNFe\emit\xNome").InnerText} OS PRODUTOS E/OU SERVIÇOS CONSTANTES DA NOTA FISCAL ELETRÔNICA INDICADA ABAIXO. " +
                            $"EMISSÃO: {GetInnerText(@"nfeProc\NFe\infNFe\ide\dhEmi").InnerText.ToDate("dd/MM/yyyy")} VALOR TOTAL: {GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vNF").InnerText.ToMoney()} " +
                            $"DESTINATÁRIO: {GetInnerText(@"nfeProc\NFe\infNFe\dest\xNome").InnerText} - {GetInnerText(@"nfeProc\NFe\infNFe\dest\enderDest\xLgr").InnerText}, {GetInnerText(@"nfeProc\NFe\infNFe\dest\enderDest\nro").InnerText} " +
                            $"{GetInnerText(@"nfeProc\NFe\infNFe\dest\enderDest\xBairro").InnerText} {GetInnerText(@"nfeProc\NFe\infNFe\dest\enderDest\xMun").InnerText}-{GetInnerText(@"nfeProc\NFe\infNFe\dest\enderDest\UF").InnerText}",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 7,
            }, 0.90, 16.35, 0.30, 0.30, round: 0.1);
            docPDF.AddField(null, null, 1.65, 4.00, 16.65, 0.30, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "NF-e",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 12,
                Bold = true
            }, null, 1.65, 4.00, 16.65, 0.60, border: false);

            string numNf = GetInnerText(@"nfeProc\NFe\infNFe\ide\nNF").InnerText.PadLeft(9, '0');
            numNf = $"{numNf.Substring(0, 3)}.{numNf.Substring(3, 3)}.{numNf.Substring(6, 3)}";
            docPDF.AddField(new Label()
            {
                TextLabel = $"Nº. {numNf}\nSérie {GetInnerText(@"nfeProc\NFe\infNFe\ide\nNF").InnerText.PadLeft(3, '0')}",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, null, 1.65, 4.00, 16.65, 1.10, border: false);

            docPDF.AddField(new Label()
            {
                TextLabel = "DATA DE RECEBIMENTO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.75, 3.45, 0.30, 1.20, round: 0.1);
            docPDF.AddField(new Label()
            {
                TextLabel = "IDENTIFICAÇÃO E ASSINATURA DO RECEBEDOR",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.75, 12.90, 3.75, 1.20, round: 0.1);

            docPDF.AddLine(0.30, 2.10, 20.65, 2.10, PDF.TypeLine.DottedLine, 0.5);
        }

        private void GerarCabecalho()
        {
            docPDF.AddField(new Label()
            {
                TextLabel = "IDENTIFICAÇÃO DO EMITENTE",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Italic = true,
                Size = 6
            }, null, 3.05, 8.60, 0.30, 2.20, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\emit\xNome").InnerText,
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Bold = true,
                Size = 11
            }, null, 0.80, 8.60, 0.30, 3.40, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = $"{GetInnerText(@"nfeProc\NFe\infNFe\emit\enderEmit\xLgr").InnerText}, " +
                            $"{GetInnerText(@"nfeProc\NFe\infNFe\emit\enderEmit\nro").InnerText}" +
                            $"{GetInnerText(@"nfeProc\NFe\infNFe\emit\enderEmit\xCpl")?.InnerText.Insert(0, " - ") ?? ""}\n" +
                            $"{GetInnerText(@"nfeProc\NFe\infNFe\emit\enderEmit\xBairro").InnerText}" +
                            $"{GetInnerText(@"nfeProc\NFe\infNFe\emit\enderEmit\CEP")?.InnerText.Insert(0, " - ") ?? ""}\n" +
                            $"{GetInnerText(@"nfeProc\NFe\infNFe\emit\enderEmit\xMun").InnerText} - " +
                            $"{GetInnerText(@"nfeProc\NFe\infNFe\emit\enderEmit\UF").InnerText}" +
                            $"{GetInnerText(@"nfeProc\NFe\infNFe\emit\enderEmit\fone")?.InnerText.Insert(0, " Fone/Fax: ") ?? ""}",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 8
            }, null, 0.80, 8.60, 0.30, 3.80, border: false);

            docPDF.AddField(null, null, 3.05, 3.60, 8.90, 2.20, round: 0.1);
            docPDF.AddField(new Label()
            {
                TextLabel = "DANFE",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Bold = true,
                Size = 14
            }, null, 1.05, 3.60, 8.90, 2.50, border: false);
            docPDF.AddField(null, new Text()
            {
                TextLabel = "Documento Auxiliar da Nota Fiscal Eletrônica",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Bold = false,
                Size = 8
            }, 1.05, 3.60, 8.90, 2.70, border: false);

            docPDF.AddField(new Label()
            {
                TextLabel = "0 - ENTRADA\n1 - SAÍDA",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 8
            }, null, 1.05, 3.60, 9.00, 3.65, border: false);

            docPDF.AddField(null, null, 0.60, 0.50, 11.80, 3.60, round: 0.1);
            docPDF.AddField(null, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\ide\tpEmis").InnerText,
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 14
            }, 0.60, 0.50, 11.85, 3.69, border: false);

            string numNf = GetInnerText(@"nfeProc\NFe\infNFe\ide\nNF").InnerText.PadLeft(9, '0');
            numNf = $"{numNf.Substring(0, 3)}.{numNf.Substring(3, 3)}.{numNf.Substring(6, 3)}";
            docPDF.AddField(new Label()
            {
                TextLabel = $"Nº. {numNf}\nSérie {GetInnerText(@"nfeProc\NFe\infNFe\ide\nNF").InnerText.PadLeft(3, '0')}",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Bold = true,
                Size = 9
            }, null, 1.05, 3.60, 8.90, 4.40, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = "Folha 1 / 1",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Italic = true,
                Size = 8
            }, null, 1.05, 3.60, 8.90, 4.95, border: false);

            docPDF.AddField(null, null, 1.35, 8.15, 12.50, 2.20, round: 0.1);
            docPDF.CodeBar(GetInnerText(@"nfeProc\protNFe\infProt\chNFe").InnerText, 0.85, 12.65, 2.75, false);
            string chaveNFe = GetInnerText(@"nfeProc\protNFe\infProt\chNFe").InnerText;
            docPDF.AddField(new Label()
            {
                TextLabel = "CHAVE DE ACESSO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = $"{chaveNFe.Substring(0, 4)} " +
                            $"{chaveNFe.Substring(4, 4)} " +
                            $"{chaveNFe.Substring(8, 4)} " +
                            $"{chaveNFe.Substring(12, 4)} " +
                            $"{chaveNFe.Substring(16, 4)} " +
                            $"{chaveNFe.Substring(20, 4)} " +
                            $"{chaveNFe.Substring(24, 4)} " +
                            $"{chaveNFe.Substring(28, 4)} " +
                            $"{chaveNFe.Substring(32, 4)} " +
                            $"{chaveNFe.Substring(36, 4)} " +
                            $"{chaveNFe.Substring(40, 4)}",
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 8,
                Bold = true
            }, 0.85, 8.15, 12.50, 3.55, round: 0.1);
            docPDF.AddField(null, null, 0.85, 8.15, 12.50, 4.40, round: 0.1);

            docPDF.AddField(null, new Text()
            {
                TextLabel = "Consulta de autenticidade no portal nacional da NF-e",
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 8,
            }, 0.85, 8.15, 12.50, 4.05, border: false);

            docPDF.AddField(null, new Text()
            {
                TextLabel = "www.nfe.fazenda.gov.br/portal ou no site da Sefaz Autorizadora",
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 8,
            }, 0.85, 8.15, 12.50, 4.50, border: false);

            docPDF.AddField(new Label()
            {
                TextLabel = "NATUREZA DA OPERAÇÃO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\ide\natOp").InnerText,
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 12.20, 0.30, 5.25, round: 0.1);
            docPDF.AddField(new Label()
            {
                TextLabel = "PROTOCOLO DE AUTORIZAÇÃO DE USO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = $"{GetInnerText(@"nfeProc\protNFe\infProt\nProt").InnerText} - {GetInnerText(@"nfeProc\protNFe\infProt\dhRecbto").InnerText.ToDateTime().ToString("dd/MM/yyyy HH:mm:ss")}",
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 8.15, 12.50, 5.25, round: 0.1);
            docPDF.AddField(new Label()
            {
                TextLabel = "INSCRIÇÃO ESTADUAL",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\emit\IE")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 6.75, 0.30, 6.00, round: 0.1);
            docPDF.AddField(new Label()
            {
                TextLabel = "INSCRIÇÃO ESTADUAL DO SUBST. TRIBUT.",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\emit\IEST")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 6.75, 7.05, 6.00, round: 0.1);
            docPDF.AddField(new Label()
            {
                TextLabel = "CNPJ / CPF",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\emit\CNPJ").InnerText.ToCNPJ(),
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 6.85, 13.80, 6.00, round: 0.1);
        }

        private void GerarDestinatario()
        {
            docPDF.AddField(new Label()
            {
                TextLabel = "DESTINATÁRIO / REMETENTE",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Bold = true,
                Size = 7
            }, null, 0.40, 20.50, 0.30, 6.90, border: false);

            docPDF.AddField(new Label()
            {
                TextLabel = "NOME / RAZÃO SOCIAL",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\dest\xNome")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 12.80, 0.30, 7.15, round: 0.1);

            string CNPJCFP = string.IsNullOrWhiteSpace(GetInnerText(@"nfeProc\NFe\infNFe\dest\CNPJ")?.InnerText) ? GetInnerText(@"nfeProc\NFe\infNFe\dest\CPF").InnerText.ToCPF() : GetInnerText(@"nfeProc\NFe\infNFe\dest\CNPJ").InnerText.ToCNPJ();
            docPDF.AddField(new Label()
            {
                TextLabel = "CNPJ / CPF",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = CNPJCFP,
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 4.20, 13.10, 7.15, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "DATA DA EMISSÃO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\ide\dhEmi").InnerText.ToDate("dd/MM/yyyy"),
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 3.35, 17.30, 7.15, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "ENDEREÇO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = $"{GetInnerText(@"nfeProc\NFe\infNFe\dest\enderDest\xLgr").InnerText}, {GetInnerText(@"nfeProc\NFe\infNFe\dest\enderDest\nro").InnerText} ",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 9.70, 0.30, 7.90, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "BAIRRO / DISTRITO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\dest\enderDest\xBairro")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 4.30, 10.00, 7.90, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "CEP",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\dest\enderDest\CEP")?.InnerText.ToCEP() ?? "",
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 3.00, 14.30, 7.90, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "DATA DA SAÍDA/ENTRADA",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\ide\dhSaiEnt").InnerText.ToDate("dd/MM/yyyy"),
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 3.35, 17.30, 7.90, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "MUNICÍPIO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\dest\enderDest\xMun")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 9.70, 0.30, 8.65, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "UF",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\dest\enderDest\UF")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 0.80, 10.00, 8.65, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "FONE / FAX",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\dest\enderDest\fone")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 3.50, 10.80, 8.65, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "INSCRIÇÃO ESTADUAL",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\dest\IE")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 3.00, 14.30, 8.65, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "HORA DA SAÍDA/ENTRADA",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\ide\dhSaiEnt").InnerText.ToDateTime().ToString("HH:mm:ss"),
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 3.35, 17.30, 8.65, round: 0.1);
        }

        private void GerarFaturaDuplicata()
        {
            docPDF.AddField(new Label()
            {
                TextLabel = "FATURA / DUPLICATA",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Bold = true,
                Size = 7
            }, null, 0.40, 20.50, 0.30, 9.55, border: false);

            docPDF.AddField(null, null, 0.85, 2.537, 0.30, 9.80, round: 0.1);
            docPDF.AddField(null, null, 0.85, 2.537, 2.837, 9.80, round: 0.1);
            docPDF.AddField(null, null, 0.85, 2.537, 5.374, 9.80, round: 0.1);
            docPDF.AddField(null, null, 0.85, 2.537, 7.911, 9.80, round: 0.1);
            docPDF.AddField(null, null, 0.85, 2.537, 10.448, 9.80, round: 0.1);
            docPDF.AddField(null, null, 0.85, 2.537, 12.985, 9.80, round: 0.1);
            docPDF.AddField(null, null, 0.85, 2.537, 15.537, 9.80, round: 0.1);
            docPDF.AddField(null, null, 0.85, 2.537, 18.059, 9.80, round: 0.1);
        }

        private void GerarCalculoImposto()
        {
            docPDF.AddField(new Label()
            {
                TextLabel = "CÁLCULO DO IMPOSTO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Bold = true,
                Size = 7
            }, null, 0.40, 20.50, 0.30, 10.80, border: false);

            docPDF.AddField(new Label()
            {
                TextLabel = "BASE DE CÁLC. DO ICMS",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 5
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vBC").InnerText.ToMoney(false),
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 0.30, 11.05, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "VALOR DO ICMS",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vICMS").InnerText.ToMoney(false),
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 2.55, 11.05, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "BASE DE CÁLC. ICMS S.T.",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 5
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vBCST").InnerText.ToMoney(false),
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 4.80, 11.05, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "VALOR DO ICMS SUBST.",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 5
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vST").InnerText.ToMoney(false),
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 7.05, 11.05, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "V. IMP. IMPORTAÇÃO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vII")?.InnerText.ToMoney(false) ?? "0,00",
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 9.30, 11.05, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "V. ICMS UF REMET.",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vICMSUFRemet")?.InnerText.ToMoney(false) ?? "0,00",
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 11.55, 11.05, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "VALOR DO FCP",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vFCP")?.InnerText.ToMoney(false) ?? "0,00",
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 13.80, 11.05, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "VALOR DO PIS",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vPIS").InnerText.ToMoney(false),
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 16.05, 11.05, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "V. TOTAL PRODUTOS",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vProd").InnerText.ToMoney(false),
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.32, 18.30, 11.05, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "VALOR DO FRETE",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vFrete").InnerText.ToMoney(false),
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 0.30, 11.80, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "VALOR DO SEGURO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vSeg").InnerText.ToMoney(false),
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 2.55, 11.80, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "DESCONTO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vDesc").InnerText.ToMoney(false),
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 4.80, 11.80, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "OUTRAS DESPESAS",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 5
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vOutro").InnerText.ToMoney(false),
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 7.05, 11.80, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "VALOR TOTAL IPI",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vIPI").InnerText.ToMoney(false),
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 9.30, 11.80, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "V. ICMS UF DEST.",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vICMSUFDest")?.InnerText.ToMoney(false) ?? "0,00",
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 11.55, 11.80, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "V. TOT. TRIB.",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vTotTrib")?.InnerText.ToMoney(false) ?? "0,00",
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 13.80, 11.80, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "VALOR DA COFINS",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vCOFINS").InnerText.ToMoney(false),
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.25, 16.05, 11.80, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "V. TOTAL DA NOTA",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\total\ICMSTot\vNF").InnerText.ToMoney(false),
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.32, 18.30, 11.80, round: 0.1);
        }

        private void GerarTransportador()
        {
            docPDF.AddField(new Label()
            {
                TextLabel = "TRANSPORTADOR / VOLUMES TRANSPORTADOS",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Bold = true,
                Size = 7
            }, null, 0.40, 20.50, 0.30, 12.70, border: false);

            docPDF.AddField(new Label()
            {
                TextLabel = "NOME / RAZÃO SOCIAL",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\transp\transporta\xNome")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 6.00, 0.30, 12.95, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "FRETE POR CONTA",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = ToFrete(GetInnerText(@"nfeProc\NFe\infNFe\transp\modFrete")?.InnerText ?? ""),
                AlignHorizontal = Element.ALIGN_CENTER,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 3.00, 6.30, 12.95, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "CÓDIGO ANTT",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\transp\veicTransp\RNTC")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 3.00, 9.30, 12.95, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "PLACA DO VEÍCULO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\transp\veicTransp\placa")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 3.00, 12.30, 12.95, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "UF",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\transp\veicTransp\UF")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 0.90, 15.30, 12.95, round: 0.1);

            string CNPJCPF = string.IsNullOrWhiteSpace(GetInnerText(@"nfeProc\NFe\infNFe\transp\transporta\CNPJ")?.InnerText ?? "") ? (GetInnerText(@"nfeProc\NFe\infNFe\transp\transporta\CPF")?.InnerText.ToCPF() ?? "") : (GetInnerText(@"nfeProc\NFe\infNFe\transp\transporta\CPF")?.InnerText.ToCNPJ() ?? "");
            docPDF.AddField(new Label()
            {
                TextLabel = "CNPJ / CPF",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = CNPJCPF,
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 4.40, 16.20, 12.95, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "ENDEREÇO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\transp\transporta\xEnder")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 9.00, 0.30, 13.70, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "MUNICÍPIO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\transp\transporta\xMun")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 6.00, 9.30, 13.70, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "UF",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\transp\transporta\xNome")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 0.90, 15.30, 13.70, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "INSCRIÇÃO ESTADUAL",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\transp\transporta\IE")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 4.40, 16.20, 13.70, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "QUANTIDADE",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\transp\vol\qVol")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 2.00, 0.30, 14.45, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "ESPÉCIE",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\transp\vol\esp")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 3.50, 2.30, 14.45, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "MARCA",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\transp\vol\marca")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 3.50, 5.80, 14.45, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "NUMERAÇÃO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\transp\vol\nVol")?.InnerText ?? "",
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 3.50, 9.30, 14.45, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "PESO BRUTO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\transp\vol\pesoB")?.InnerText.ToDecimal(3).ToString() ?? "",
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 3.95, 12.80, 14.45, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "PESO LÍQUIDO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\transp\vol\pesoL")?.InnerText.ToDecimal(3).ToString() ?? "",
                AlignHorizontal = Element.ALIGN_RIGHT,
                AlignVertical = Element.ALIGN_BOTTOM,
                Font = BaseFont.TIMES_ROMAN,
                Size = 10,
                Bold = true
            }, 0.75, 3.85, 16.75, 14.45, round: 0.1);
        }

        private void GerarDadosProdutoServico()
        {
            docPDF.AddField(new Label()
            {
                TextLabel = "DADOS DOS PRODUTOS / SERVIÇOS",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Bold = true,
                Size = 7
            }, null, 0.40, 20.50, 0.30, 15.35, border: false);

            docPDF.AddField(null, null, 11.00, 20.30, 0.30, 15.60, round: 0.1);

            docPDF.AddField(new Label()
            {
                TextLabel = "CÓDIGO PRODUTO",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.55, 1.95, 0.30, 15.60, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = "DESCRIÇÃO DO PRODUTO / SERVIÇO",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.55, 5.45, 2.25, 15.60, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = "NCM/SH",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.55, 1.30, 7.70, 15.60, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = "O/CST",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.55, 1.00, 9.00, 15.60, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = "CFOP",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.55, 0.80, 10.00, 15.60, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = "UN",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.55, 0.60, 10.80, 15.60, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = "QUANT",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.55, 1.40, 11.40, 15.60, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = "VALOR\nUNIT",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.55, 1.20, 12.80, 15.60, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = "VALOR\nTOTAL",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.55, 1.20, 14.00, 15.60, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = "B.CÁLC\nICMS",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.55, 1.20, 15.20, 15.60, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = "VALOR\nICMS",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.55, 1.20, 16.40, 15.60, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = "VALOR\nIPI",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.55, 1.00, 17.60, 15.60, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = "ALÍQ.\nICMS",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.55, 0.70, 18.60, 15.60, border: false);
            docPDF.AddField(new Label()
            {
                TextLabel = "ALÍQ. IPI",
                AlignHorizontal = Element.ALIGN_CENTER,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 0.55, 1.30, 19.30, 15.60, border: false);

            docPDF.AddLine(0.30, 16.10, 20.60, 16.10, PDF.TypeLine.ContinuousLine, 0.5);

            docPDF.AddLine(2.23, 15.60, 2.23, 26.60, PDF.TypeLine.ContinuousLine, 0.5);
            docPDF.AddLine(7.70, 15.60, 7.70, 26.60, PDF.TypeLine.ContinuousLine, 0.5);
            docPDF.AddLine(9.00, 15.60, 9.00, 26.60, PDF.TypeLine.ContinuousLine, 0.5);
            docPDF.AddLine(10.00, 15.60, 10.00, 26.60, PDF.TypeLine.ContinuousLine, 0.5);
            docPDF.AddLine(10.80, 15.60, 10.80, 26.60, PDF.TypeLine.ContinuousLine, 0.5);
            docPDF.AddLine(11.40, 15.60, 11.40, 26.60, PDF.TypeLine.ContinuousLine, 0.5);
            docPDF.AddLine(12.80, 15.60, 12.80, 26.60, PDF.TypeLine.ContinuousLine, 0.5);
            docPDF.AddLine(14.00, 15.60, 14.00, 26.60, PDF.TypeLine.ContinuousLine, 0.5);
            docPDF.AddLine(15.20, 15.60, 15.20, 26.60, PDF.TypeLine.ContinuousLine, 0.5);
            docPDF.AddLine(16.40, 15.60, 16.40, 26.60, PDF.TypeLine.ContinuousLine, 0.5);
            docPDF.AddLine(17.60, 15.60, 17.60, 26.60, PDF.TypeLine.ContinuousLine, 0.5);
            docPDF.AddLine(18.60, 15.60, 18.60, 26.60, PDF.TypeLine.ContinuousLine, 0.5);
            docPDF.AddLine(19.30, 15.60, 19.30, 26.60, PDF.TypeLine.ContinuousLine, 0.5);

            double positionY = 0;
            foreach (XmlNode item in docXml.GetElementsByTagName("det"))
            {
                double sumY = 0.27;
                docPDF.AddField(null,
                    new Text()
                    {
                        TextLabel = item["prod"]["cProd"].InnerText,
                        AlignHorizontal = Element.ALIGN_CENTER,
                        AlignVertical = Element.ALIGN_TOP,
                        Font = BaseFont.TIMES_ROMAN,
                        Size = 7
                    }, 0.45, 1.95, 0.30, 16.05 + positionY, border: false);
                docPDF.AddField(null,
                    new Text()
                    {
                        TextLabel = item["prod"]["xProd"].InnerText,
                        AlignHorizontal = Element.ALIGN_LEFT,
                        AlignVertical = Element.ALIGN_TOP,
                        Font = BaseFont.TIMES_ROMAN,
                        Size = 7
                    }, 0.45, 5.45, 2.25, 16.05 + positionY, border: false);



                sumY = sumY * Math.Ceiling(item["prod"]["xProd"].InnerText.Length / 36f);

                docPDF.AddField(null,
                    new Text()
                    {
                        TextLabel = item["prod"]["NCM"].InnerText,
                        AlignHorizontal = Element.ALIGN_CENTER,
                        AlignVertical = Element.ALIGN_TOP,
                        Font = BaseFont.TIMES_ROMAN,
                        Size = 7
                    }, 0.45, 1.30, 7.70, 16.05 + positionY, border: false);

                string octs = item["imposto"]["ICMS"].ChildNodes[0]["orig"]?.InnerText ?? "";

                if (item["imposto"]["ICMS"].ChildNodes[0]["CST"] == null)
                {
                    octs += item["imposto"]["ICMS"].ChildNodes[0]["CSOSN"].InnerText;
                }
                else
                {
                    octs += item["imposto"]["ICMS"].ChildNodes[0]["CST"].InnerText;
                }

                docPDF.AddField(null,
                    new Text()
                    {
                        TextLabel = octs,
                        AlignHorizontal = Element.ALIGN_CENTER,
                        AlignVertical = Element.ALIGN_TOP,
                        Font = BaseFont.TIMES_ROMAN,
                        Size = 7
                    }, 0.45, 1.00, 9.00, 16.05 + positionY, border: false);
                docPDF.AddField(null,
                    new Text()
                    {
                        TextLabel = item["prod"]["CFOP"].InnerText,
                        AlignHorizontal = Element.ALIGN_CENTER,
                        AlignVertical = Element.ALIGN_TOP,
                        Font = BaseFont.TIMES_ROMAN,
                        Size = 7
                    }, 0.45, 0.80, 10.00, 16.05 + positionY, border: false);
                docPDF.AddField(null,
                    new Text()
                    {
                        TextLabel = item["prod"]["uCom"].InnerText,
                        AlignHorizontal = Element.ALIGN_CENTER,
                        AlignVertical = Element.ALIGN_TOP,
                        Font = BaseFont.TIMES_ROMAN,
                        Size = 7
                    }, 0.45, 0.60, 10.80, 16.05 + positionY, border: false);
                docPDF.AddField(null,
                    new Text()
                    {
                        TextLabel = item["prod"]["qCom"].InnerText.ToDecimal(4).ToString(),
                        AlignHorizontal = Element.ALIGN_RIGHT,
                        AlignVertical = Element.ALIGN_TOP,
                        Font = BaseFont.TIMES_ROMAN,
                        Size = 7
                    }, 0.45, 1.40, 11.40, 16.05 + positionY, border: false);
                docPDF.AddField(null,
                    new Text()
                    {
                        TextLabel = item["prod"]["vUnCom"].InnerText.ToDecimal(4).ToString(),
                        AlignHorizontal = Element.ALIGN_RIGHT,
                        AlignVertical = Element.ALIGN_TOP,
                        Font = BaseFont.TIMES_ROMAN,
                        Size = 7
                    }, 0.45, 1.20, 12.80, 16.05 + positionY, border: false);
                docPDF.AddField(null,
                    new Text()
                    {
                        TextLabel = item["prod"]["vProd"].InnerText.ToMoney(false),
                        AlignHorizontal = Element.ALIGN_RIGHT,
                        AlignVertical = Element.ALIGN_TOP,
                        Font = BaseFont.TIMES_ROMAN,
                        Size = 7
                    }, 0.45, 1.20, 14.00, 16.05 + positionY, border: false);
                docPDF.AddField(null,
                    new Text()
                    {
                        TextLabel = item["imposto"]["ICMS"].ChildNodes[0]["vBC"]?.ToMoney(false) ?? "0,00",
                        AlignHorizontal = Element.ALIGN_RIGHT,
                        AlignVertical = Element.ALIGN_TOP,
                        Font = BaseFont.TIMES_ROMAN,
                        Size = 8
                    }, 0.45, 1.20, 15.20, 16.05 + positionY, border: false);
                docPDF.AddField(null,
                    new Text()
                    {
                        TextLabel = item["imposto"]["ICMS"].ChildNodes[0]["vICMS"]?.ToMoney(false) ?? "0,00",
                        AlignHorizontal = Element.ALIGN_RIGHT,
                        AlignVertical = Element.ALIGN_TOP,
                        Font = BaseFont.TIMES_ROMAN,
                        Size = 8
                    }, 0.45, 1.20, 16.40, 16.05 + positionY, border: false);
                docPDF.AddField(null,
                    new Text()
                    {
                        TextLabel = item["imposto"]["IPI"]?.ChildNodes[0]["vIPI"]?.ToMoney(false) ?? "",
                        AlignHorizontal = Element.ALIGN_RIGHT,
                        AlignVertical = Element.ALIGN_TOP,
                        Font = BaseFont.TIMES_ROMAN,
                        Size = 8
                    }, 0.45, 1.00, 17.60, 16.05 + positionY, border: false);
                docPDF.AddField(null,
                    new Text()
                    {
                        TextLabel = item["imposto"]["IPI"]?.ChildNodes[0]["pICMS"]?.ToDecimal().ToString() ?? "0,00",
                        AlignHorizontal = Element.ALIGN_RIGHT,
                        AlignVertical = Element.ALIGN_TOP,
                        Font = BaseFont.TIMES_ROMAN,
                        Size = 8
                    }, 0.45, 0.70, 18.60, 16.05 + positionY, border: false);
                docPDF.AddField(null,
                    new Text()
                    {
                        TextLabel = item["imposto"]["ICMS"].ChildNodes[0]["pIPI"]?.ToDecimal().ToString() ?? "",
                        AlignHorizontal = Element.ALIGN_RIGHT,
                        AlignVertical = Element.ALIGN_TOP,
                        Font = BaseFont.TIMES_ROMAN,
                        Size = 8
                    }, 0.45, 1.30, 19.30, 16.05 + positionY, border: false);

                positionY += sumY;
                docPDF.AddLine(0.35, 16.05 + positionY + 0.1, 20.60, 16.05 + positionY + 0.1, PDF.TypeLine.DottedLine, 0.1f);
            }
        }

        private void GerarDadosAdicionais()
        {
            docPDF.AddField(new Label()
            {
                TextLabel = "DADOS ADICIONAIS",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Bold = true,
                Size = 7
            }, null, 0.40, 20.50, 0.30, 26.75, border: false);

            docPDF.AddField(new Label()
            {
                TextLabel = "INFORMAÇÕES COMPLEMENTARES",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, new Text()
            {
                TextLabel = GetInnerText(@"nfeProc\NFe\infNFe\infAdic\infCpl")?.InnerText.Replace(";", "\n") ?? "",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, 2.35, 13.50, 0.30, 27.00, round: 0.1);
            docPDF.AddField(new Label()
            {
                TextLabel = "RESERVADO AO FISCO",
                AlignHorizontal = Element.ALIGN_LEFT,
                Font = BaseFont.TIMES_ROMAN,
                Size = 6
            }, null, 2.35, 6.80, 13.80, 27.00, round: 0.1);
        }



        private XmlNode GetInnerText(string pathXml)
        {
            string[] raiz = pathXml.Split('\\');
            XmlNode node = docXml;
            for (int i = 0; i < raiz.Length; i++)
            {
                node = node[raiz[i]];

                if (node == null)
                {
                    return null;
                }
            }

            return node;
        }

        private string ToFrete(string value)
        {
            switch (value)
            {
                case "0":
                    return string.Format("({0}) Emitente", value);
                case "1":
                    return string.Format("({0}) Dest./Remet.", value);
                case "2":
                    return string.Format("({0}) Terceiros", value);
                case "9":
                    return string.Format("({0}) Sem frete", value);
                default:
                    return value;
            }
        }
    }
}
