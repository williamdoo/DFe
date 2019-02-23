using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Aplicacao
{
    /// <summary>
    /// Classe de assinatura digital
    /// </summary>
    public class AssinaturaDigital
    {
        /// <summary>
        /// Documento XML Assinato
        /// </summary>
        public XmlDocument XMLDoc { get; private set; }
        /// <summary>
        /// Lista de erros
        /// </summary>
        public string Erro { get; private set; }

        /// <summary>
        /// Assinar o arquivo xml
        /// </summary>
        /// <param name="XMLString">Arquivo xml serializado</param>
        /// <param name="RefUri">URI a ser assinada (infNFe para NFe)</param>
        /// <param name="X509Cert">Certificado digital</param>
        /// <returns>Retorna true caso o processo de assinatura foi realizado com sucesso, caso contrário retorna false</returns>
        public bool Assinar(string XMLString, string RefUri, X509Certificate2 X509Cert)
        {
            XmlDocument doc = new XmlDocument { PreserveWhitespace = false };

            XMLDoc = new XmlDocument { PreserveWhitespace = false };
            Erro = "";

            doc.LoadXml(XMLString);

            try
            {
                SignedXml signedXml = new SignedXml(doc);
                signedXml.SigningKey = X509Cert.PrivateKey;

                Reference reference = new Reference();
                XmlAttributeCollection uri = doc.GetElementsByTagName(RefUri).Item(0).Attributes;
                foreach (XmlAttribute atributo in uri)
                {
                    if (atributo.Name == "Id")
                    {
                        reference.Uri = "#" + atributo.Value;

                        break;
                    }
                }

                reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                reference.AddTransform(new XmlDsigC14NTransform());

                signedXml.AddReference(reference);

                KeyInfo keyInfo = new KeyInfo();
                keyInfo.AddClause(new KeyInfoX509Data(X509Cert));

                signedXml.KeyInfo = keyInfo;

                signedXml.ComputeSignature();

                XmlElement xmlDigitalSignature = signedXml.GetXml();

                var node = FindNode(doc.ChildNodes, RefUri);
                node.ParentNode.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

                XmlDocument xmlOut = new XmlDocument();
                xmlOut.LoadXml(doc.OuterXml);
                XMLDoc = xmlOut.ChangeXmlEncoding("utf-8");
                return true;
            }
            catch (Exception ex)
            {
                Erro = "ERRO AO ASSINAR O DOCUMENTO XML\n\n" + ex.Message;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        private XmlNode FindNode(XmlNodeList list, string nodeName)
        {
            if (list.Count > 0)
            {
                foreach (XmlNode node in list)
                {
                    if (node.Name.Equals(nodeName)) return node;
                    if (node.HasChildNodes)
                    {
                        XmlNode nodeFound = FindNode(node.ChildNodes, nodeName);
                        if (nodeFound != null)
                            return nodeFound;
                    }
                }
            }
            return null;
        }
    }
}
