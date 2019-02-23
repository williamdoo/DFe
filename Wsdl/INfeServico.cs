using System.Xml;

namespace Wsdl
{
    public interface INfeServico
    {
        nfeCabecMsg nfeCabecMsg { get; set; }
        XmlNode Execute(XmlNode nfeDadosMsg);
    }
}
