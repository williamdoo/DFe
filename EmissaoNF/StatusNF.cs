using System;

namespace EmissaoNF
{
    public class StatusNF: App
    {
        public bool VerificarStatusNFCe(string tpAmb)
        {
            try
            {
                using (Wsdl.NFCe.Status.NfeStatusServico4 ws = new Wsdl.NFCe.Status.NfeStatusServico4(WebServiceNFCe.WebService, Certificado.X509Certificado, TimeOut))
                {
                    
                }
            }
            catch (Exception ex)
            {
                Erro = $"ERRO NO PROCESSO DE ENVIO\n\n{ex.Message}";
            }

            return false;
        }
    }
}
