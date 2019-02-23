using System.Xml;

namespace Wsdl
{
    public interface INfeServicoAutorizacao: INfeServico
    {
        XmlNode ExecuteZip(string nfeDadosMsgZip);
    }
}
