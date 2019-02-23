using Aplicacao;
using System.Web.Services.Protocols;

namespace Wsdl
{
    public class nfeCabecMsg: SoapHeader
    {
        public Estados cUF { get; set; }
        public string versaoDados { get; set; }
    }
}
