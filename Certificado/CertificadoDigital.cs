using System;
using System.Security.Cryptography.X509Certificates;

namespace Certificado
{
    /// <summary>
    /// Classe do certificado digital
    /// </summary>
    public class CertificadoDigital
    {
        /// <summary>
        /// Certificado Selecionado
        /// </summary>
        public X509Certificate2 X509Certificado { get; private set; }

        /// <summary>
        /// Erros que foram encontrado
        /// </summary>
        public string Erros { get; private set; }

        /// <summary>
        /// Buscar um certificado digital instalado
        /// </summary>
        /// <param name="nomeCert">Nome do certificado digital, caso necessario</param>
        /// <param name="nroSerie">Série do certificado digital, caso necessário</param>
        /// <returns>Retorna true caso foi selecionado um certificado digital, caso contrário retorna false</returns>
        public bool BuscarCertificado(string nomeCert = null, string nroSerie = null)
        {
            Erros = "";
            try
            {
                if (X509Certificado != null)
                {
                    return true;
                }

                X509Certificado = new X509Certificate2();

                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection certificates = store.Certificates;
                X509Certificate2Collection collection = certificates.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false);
                X509Certificate2Collection scollection;

                if (string.IsNullOrWhiteSpace(nomeCert) && string.IsNullOrWhiteSpace(nroSerie))
                {
                    scollection = X509Certificate2UI.SelectFromCollection(collection, "Certificado(s) Digital(is) disponível(is)", "Selecione o Certificado Digital", X509SelectionFlag.SingleSelection);
                }
                else if (!string.IsNullOrEmpty(nomeCert))
                {
                    scollection = collection.Find(X509FindType.FindBySubjectDistinguishedName, nomeCert, false);
                }
                else
                {
                    scollection = collection.Find(X509FindType.FindBySerialNumber, nroSerie, true);
                }

                if (scollection.Count == 0)
                {
                    X509Certificado.Reset();
                    Erros = "Não foi encontrado certificado instalado";
                    store.Close();
                    return false;
                }
                else
                {
                    X509Certificado = scollection[0];
                }

                store.Close();
                return true;

            }
            catch (Exception ex)
            {
                Erros = "ERRO AO BUSCAR UM CERETIFICADO\n\n" + ex.Message;
                return false;
            }
        }
    }
}
