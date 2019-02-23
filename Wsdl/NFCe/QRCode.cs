using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wsdl.NFCe
{
    public class QRCode
    {
        public string  ChNfe { get; set; }
        public string NVersao { get; set; }
        public string TpAmb { get; set; }
        public string CDest { get; set; }
        public string DhEmi { get; set; }
        public string VNF { get; set; }
        public string VICMS { get; set; }
        public string DigVal { get; set; }
        public string CIdToken { get; set; }
        public string Csc { get; set; }
        public string CHashQRCode { get; set; }
        public string URL { get; set; }
        public string VersaoXML { get; set; }
        public bool Contingencia { get; set; }
        public string TextQRCode { get; set; }

        public void GerarURLQRCode()
        {
            int idToken = int.Parse(CIdToken);
            string parametros = "", hash;

            if (Contingencia)
            {
                DateTime dEmis = Convert.ToDateTime(DhEmi);
                string dia = dEmis.Day.ToString().PadLeft(2, '0');

                parametros = $"{ChNfe}|{NVersao}|{TpAmb}|{dia}|{VNF}|{ConveterHexa(DigVal)}|{idToken}";
            }
            else
            {
                parametros = $"{ChNfe}|{NVersao}|{TpAmb}|{idToken}";                
            }

            hash = ConvertSHA1(parametros + Csc).ToUpper();
            TextQRCode = $"{URL}?p={parametros}|{hash}";
        }

        private string ConvertSHA1(string value)
        {
            string str = value;
            SHA1 hash = SHA1.Create();
            StringBuilder strBuider = new StringBuilder();

            byte[] array = ConverterByte(str);
            array = hash.ComputeHash(array);

            foreach (byte item in array)
            {
                strBuider.Append(item.ToString("x2"));
            }

            return strBuider.ToString();
        }

        /// <summary>
        /// Converter para Byte
        /// </summary>
        /// <param name="value">Valor que será convetido</param>
        /// <returns>Retorno do Byte</returns>
        private byte[] ConverterByte(string value)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            return encoding.GetBytes(value);
        }

        /// <summary>
        /// Conveter para Hexa
        /// </summary>
        /// <param name="value">Valor que será convertido</param>
        /// <returns>Retorno do Hexa</returns>
        private string ConveterHexa(string value)
        {
            string vl = value;
            string hex = "";

            foreach (char c in vl)
                hex += ((int)c).ToString("x");

            return hex;
        }
    }
}
