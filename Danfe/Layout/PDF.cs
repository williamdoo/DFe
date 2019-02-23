using Danfe.BaseConverters;
using Danfe.Componente;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danfe.Layout
{
    /// <summary>
    /// Classe para gerar o documento
    /// </summary>
    public class PDF
    {
        /// <summary>
        /// Tipo de linhas
        /// </summary>
        public enum TypeLine
        {
            DottedLine = 0,
            ContinuousLine = 1
        }

        /// <summary>
        /// Conteudo do PDF
        /// </summary>
        PdfContentByte contentByte;

        /// <summary>
        /// Documento PDV
        /// </summary>
        private Document Doc { get; set; }

        /// <summary>
        /// Escrever no PDF
        /// </summary>
        private PdfWriter Writer { get; set; }

        /// <summary>
        /// Classe para gerar o documento
        /// </summary>
        /// <param name="name">Nome do documento</param>
        public PDF(string name)
            : this(name, 0, 0, 0, 0)
        {

        }

        /// <summary>
        /// Classe para gerar o documento
        /// </summary>
        /// <param name="name">Nome do documento</param>
        /// <param name="marginLeft">Margem da Esquerda</param>
        /// <param name="marginTop">Margem Superior</param>
        /// <param name="marginRight">Margem da Direita</param>
        /// <param name="marginBottom">Marge Inferior</param>
        public PDF(string name, float marginLeft, float marginTop, float marginRight, float marginBottom)
        {
            Doc = new Document(PageSize.A4);
            Doc.SetMargins(marginLeft, marginRight, marginTop, marginBottom);
            Writer = PdfWriter.GetInstance(Doc, new FileStream($"{name}.pdf", FileMode.Create));
        }

        /// <summary>
        /// Abri o documento para realizar a escrita
        /// </summary>
        public void Open()
        {
            Doc.Open();
            contentByte = Writer.DirectContent;
        }

        /// <summary>
        /// Adicionar campo
        /// </summary>
        /// <param name="label">Rótulo do campo</param>
        /// <param name="text">Texto do campo</param>
        /// <param name="height">Altura do campo</param>
        /// <param name="width">Largura do campo</param>
        /// <param name="positionX">Posição X</param>
        /// <param name="positionY">Posição Y</param>
        /// <param name="border">Inserir borda</param>
        /// <param name="round">Arredondar borda</param>
        public void AddField(Label label, Text text, double height, double width, double positionX, double positionY, bool border = true, double round = 0)
        {
            var positions = CalculatePositions(positionX, positionY, height);
            var size = CalculateHeigthWidth(width, height);

            if (border)
            {
                contentByte.SetLineDash(1);
                contentByte.RoundRectangle(positions.Item1, positions.Item2, size.Item1, size.Item2, CalculateRound(round));
            }

            AddLabel(label, positions.Item1, positions.Item2, size.Item2, size.Item1);
            AddText(text, label != null, positions.Item1, positions.Item2, size.Item2, size.Item1);

            contentByte.Stroke();
        }

        /// <summary>
        /// Adicionar linhas
        /// </summary>
        /// <param name="fromX">Posição de X</param>
        /// <param name="fromY">Posição de Y</param>
        /// <param name="toX">Posição para X</param>
        /// <param name="toY">Posição para Y</param>
        /// <param name="line">Tipo de linha</param>
        /// <param name="phase">Estagio de espaço quando for utilizar a linha pontilhada</param>
        public void AddLine(double fromX, double fromY, double toX, double toY, TypeLine line, double phase)
        {
            var from = CalculateFromTO(fromX, fromY);
            var to = CalculateFromTO(toX, toY);

            if (line == TypeLine.DottedLine)
            {
                contentByte.SetLineDash(4f, phase);
            }
            else
            {
                contentByte.SetLineDash(1);
            }
            contentByte.MoveTo(from.Item1, from.Item2);
            contentByte.LineTo(to.Item1, to.Item2);
            contentByte.Stroke();
        }

        /// <summary>
        /// Adicionar um rótulo
        /// </summary>
        /// <param name="label">Rótulo do campo</param>
        /// <param name="positionX">Posição X</param>
        /// <param name="positionY">Posição Y</param>
        /// <param name="heigth">Altura</param>
        /// <param name="width">Largura</param>
        private void AddLabel(Label label, double positionX, double positionY, double heigth, double width)
        {
            if (label != null)
            {
                if (label.Bold && label.Italic)
                {
                    contentByte.SetFontAndSize(BaseFont.CreateFont(BaseFont.TIMES_BOLDITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), label.Size);
                }
                else if (label.Bold)
                {
                    contentByte.SetFontAndSize(BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), label.Size);
                }
                else if (label.Italic)
                {
                    contentByte.SetFontAndSize(BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), label.Size);
                }
                else
                {
                    contentByte.SetFontAndSize(BaseFont.CreateFont(label.Font, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), label.Size);
                }

                string[] textLines = NewLine(label.TextLabel);
                float sizeLine = 0;

                foreach (string text in textLines)
                {
                    contentByte.ShowTextAligned(label.AlignHorizontal, text, PositionsXLabel(label.AlignHorizontal, positionX, width), (float)(positionY + heigth - 6) - sizeLine, 0);
                    sizeLine += label.Size;
                }
            }
        }

        /// <summary>
        /// Adicionar um texto
        /// </summary>
        /// <param name="text">Texto do campo</param>
        /// <param name="containsLabel">Contem um rótulo</param>
        /// <param name="positionX">Posição X</param>
        /// <param name="positionY">Posição Y</param>
        /// <param name="heigth">Altura</param>
        /// <param name="width">Largura</param>
        private void AddText(Text text, bool containsLabel, double positionX, double positionY, double heigth, double width)
        {
            if (text != null)
            {
                int spaceLabel = 8;
                if (text.Bold && text.Italic)
                {
                    contentByte.SetFontAndSize(BaseFont.CreateFont(BaseFont.TIMES_BOLDITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), text.Size);
                }
                else if (text.Bold)
                {
                    contentByte.SetFontAndSize(BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), text.Size);
                }
                else if (text.Italic)
                {
                    contentByte.SetFontAndSize(BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), text.Size);
                }
                else
                {
                    contentByte.SetFontAndSize(BaseFont.CreateFont(text.Font, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), text.Size);
                }

                if (containsLabel)
                {
                    spaceLabel = 12;
                }
                string[] textLines;
                if (text.TextLabel.Contains("\n"))
                {
                    textLines = NewLine(text.TextLabel);
                }
                else
                {
                    textLines = NewLine(text.TextLabel, text.Font, text.Size, width);
                }

                float sizeLine = 0;

                foreach (string textLine in textLines)
                {
                    contentByte.ShowTextAligned(text.AlignHorizontal, textLine, PositionsXLabel(text.AlignHorizontal, positionX, width), PositionsYLabel(text.AlignVertical, positionY - spaceLabel - sizeLine, heigth), 0);
                    sizeLine += text.Size;
                }
            }
        }

        /// <summary>
        /// Adiconar um código de barra no formate 128
        /// </summary>
        /// <param name="value">Valor do código de barra</param>
        /// <param name="height">Altura</param>
        /// <param name="positionX">Posição X</param>
        /// <param name="positionY">Posição Y</param>
        /// <param name="valueBarCode">Mostrar o valor do códgio de barra</param>
        public void CodeBar(string value, double height, double positionX, double positionY, bool valueBarCode)
        {
            Barcode128 bar = new Barcode128();
            bar.Code = value;
            bar.Size = 1;
            iTextSharp.text.Image img128 = bar.CreateImageWithBarcode(contentByte, BaseColor.BLACK, (valueBarCode ? BaseColor.BLACK : BaseColor.WHITE));
            var positions = CalculatePositions(positionX, positionY, height);
            img128.SetAbsolutePosition((float)positions.Item1, (float)positions.Item2);
            contentByte.AddImage(img128);
        }

        /// <summary>
        /// Verificar se o texto informado tem quebra de linha
        /// </summary>
        /// <param name="text">Texto informado</param>
        /// <returns>Retorna um Array de String</returns>
        private string[] NewLine(string text)
        {
            string[] lines;
            lines = text.Split('\n');

            return lines;
        }

        /// <summary>
        /// Verificar se o texto informado vai gerar mais de uma linha dentro do campo
        /// </summary>
        /// <param name="text">Texto informado</param>
        /// <param name="nameFont">Nome da fonte</param>
        /// <param name="sizeFonte">Tamanho da fonte</param>
        /// <param name="widthField">Largura do campo</param>
        /// <returns>Retorna um Array de String</returns>
        private string[] NewLine(string text, string nameFont, float sizeFonte, double widthField)
        {
            string[] words = text.Split(' ');
            List<string> lines = new List<string>();
            double width;
            string tempText = "";
            string nextWord = "";
            System.Drawing.Font font = new System.Drawing.Font(nameFont, sizeFonte, GraphicsUnit.Point);

            for (int i = 0; i < words.Length; i++)
            {
                tempText += $"{words[i]} ";

                if (words.Length > (i + 1))
                {
                    nextWord = words[(i + 1)];
                }

                using (var graphics = Graphics.FromImage(new Bitmap(1, 1)))
                {
                    width = (int)graphics.MeasureString(tempText + nextWord, font).Width;
                    width = (width / Converters.valueMillimeter) * 52;
                }

                if (width >= widthField)
                {
                    lines.Add(tempText);

                    tempText = "";
                }
            }

            if (!string.IsNullOrWhiteSpace(tempText))
            {
                lines.Add(tempText);
            }

            return lines.ToArray();
        }

        /// <summary>
        /// Formatar a posição X do rótulo dentra do campo
        /// </summary>
        /// <param name="alignHorizontal">Alinhamento horizontal</param>
        /// <param name="positionX">Posição X</param>
        /// <param name="width">Largura</param>
        /// <returns>Retonna um valor para informa a posição X do rótulo dentro do campo</returns>
        private float PositionsXLabel(int alignHorizontal, double positionX, double width)
        {
            switch (alignHorizontal)
            {
                case PdfContentByte.ALIGN_LEFT:
                    return (float)(positionX + 2);
                case PdfContentByte.ALIGN_CENTER:
                    return (float)(positionX + (width / 2));
                default:
                    return (float)(positionX + width + 1);
            }

        }

        /// <summary>
        /// Formatar a posição Y do rótulo dentra do campo
        /// </summary>
        /// <param name="alignVerfical">Alinhamento vertical</param>
        /// <param name="positionY">Posição Y</param>
        /// <param name="heigth">Altura</param>
        /// <returns>Retonna um valor para informa a posição Y do rótulo dentro do campo</returns>
        private float PositionsYLabel(int alignVerfical, double positionY, double width)
        {
            switch (alignVerfical)
            {
                case Element.ALIGN_TOP:
                    return (float)(positionY + width - 1);
                case Element.ALIGN_CENTER:
                    return (float)(positionY + (width / 2) + 7);
                case Element.ALIGN_BOTTOM:
                    return (float)(positionY + 14);
                default:
                    return (float)(positionY + width - 2);
            }
        }

        /// <summary>
        /// Calcula as posições X e Y
        /// </summary>
        /// <param name="positionX">Posição X</param>
        /// <param name="positionY">Posição Y</param>
        /// <param name="height">Altura</param>
        /// <returns>Retorna um conjuto de valores Item1 e Item2</returns>
        private Tuple<double, double> CalculatePositions(double positionX, double positionY, double height)
        {
            double positionTop = Math.Round(Writer.PageSize.Height / 28.346, 2);

            double x = (positionX / Converters.valueConveter) * Converters.valueMillimeter;
            double y = ((positionTop - height - positionY) / Converters.valueConveter) * Converters.valueMillimeter;

            return Tuple.Create(x, y);
        }

        /// <summary>
        /// Calcula a altura e largura
        /// </summary>
        /// <param name="width">Lagura</param>
        /// <param name="height">Altura</param>
        /// <returns>Retorno um conjuto de valores Item1 e Item2</returns>
        private Tuple<double, double> CalculateHeigthWidth(double width, double height)
        {
            double positionTop = Math.Round(Writer.PageSize.Height / 28.346, 2);

            double h = (height / Converters.valueConveter) * Converters.valueMillimeter;
            double w = (width / Converters.valueConveter) * Converters.valueMillimeter;

            return Tuple.Create(w, h);
        }

        /// <summary>
        /// Calcula arredodamento da borda
        /// </summary>
        /// <param name="round">Arredodamento</param>
        /// <returns>Retonro o valor de arregondamento</returns>
        private double CalculateRound(double round)
        {
            if (round == 0)
            {
                return round;
            }

            return (round / Converters.valueConveter) * Converters.valueMillimeter;
        }

        /// <summary>
        /// Calculo as posições X e Y do Inicio e Até
        /// </summary>
        /// <param name="positionX">Posição X</param>
        /// <param name="positionY">Posição Y</param>
        /// <returns>Retorna um conjuto de valores Item1 e Item2</returns>
        private Tuple<double, double> CalculateFromTO(double positionX, double positionY)
        {
            double positionTop = Math.Round(Writer.PageSize.Height / 28.346, 2);

            double x = (positionX / Converters.valueConveter) * Converters.valueMillimeter;
            double y = ((positionTop - positionY) / Converters.valueConveter) * Converters.valueMillimeter;

            return Tuple.Create(x, y);
        }

        /// <summary>
        /// Fecha o documento
        /// </summary>
        public void Close()
        {
            contentByte.Stroke();
            Doc.Close();
        }
    }
}
