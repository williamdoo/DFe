using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Aplicacao
{
    /// <summary>
    /// Classe para manipular o XML de um documento fiscal
    /// </summary>
    public static class ManipularXML
    {
        /// <summary>
        /// Salvar um objeto em modo XML
        /// </summary>
        /// <typeparam name="T">Objeto</typeparam>
        /// <param name="type">Tipo do Objeto</param>
        /// <param name="path">Caminho será salvo</param>
        /// <param name="nameSpace">Namespace do documento fiscal, utilizado em documentos NF-e/NFC-e</param>
        public static void Salvar<T>(this T type, string path, bool nameSpace = true)
        {
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(type.GetType());

            System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();
            ns.Add("", (nameSpace ? "http://www.portalfiscal.inf.br/nfe" : ""));

            using (XmlWriter file = XmlWriter.Create(path))
            {
                xs.Serialize(file, type, ns);
            }
        }

        /// <summary>
        /// Converter para um Documento XML
        /// </summary>
        /// <typeparam name="T">Objeto</typeparam>
        /// <param name="type">Tipo do Objeto</param>
        /// <returns>Retorna um XmlDocumento para minipular</returns>
        public static XmlDocument ToXmlDocument<T>(this T type)
        {
            try
            {
                XmlDocument xml = new XmlDocument() { PreserveWhitespace = false };
                xml.LoadXml(type.ToXmlString());
                return xml.ChangeXmlEncoding("utf-8");
            }
            catch
            {
                return new XmlDocument();
            }
        }

        /// <summary>
        /// Converter para uma cadeia de caracteres o XML (string)
        /// </summary>
        /// <typeparam name="T">Objeto</typeparam>
        /// <returns>Retorna uma string do documento XML</returns>
        public static string ToXmlString<T>(this T type)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(type.GetType());

                System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();
                ns.Add("", "http://www.portalfiscal.inf.br/nfe");
                using (StringWriter sw = new StringWriter())
                {
                    using (XmlWriter value = XmlWriter.Create(sw))
                    {
                        xs.Serialize(value, type, ns);
                        return sw.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Exception - " + ex.ToString();
            }
        }

        /// <summary>
        ///  Converter o XML para uma classe tipada
        /// </summary>
        /// <typeparam name="T">Objeto</typeparam>
        /// <param name="xml"></param>
        /// <returns>Retorna um objeto tipado</returns>
        public static T ToXmlClass<T>(this string xml)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));

                using (StringReader sr = new StringReader(xml))
                {
                    using (XmlReader value = XmlReader.Create(sr))
                    {
                        return (T)xs.Deserialize(value);
                    }
                }
            }
            catch
            {
                return (T)new object();
            }
        }

        /// <summary>
        /// Carregar o XML para uma objeto tipado
        /// </summary>
        /// <typeparam name="T">Objeto</typeparam>
        /// <param name="path">Camanho do XML</param>
        /// <returns></returns>
        public static T Load<T>(string path)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                using (System.IO.StreamReader file = new System.IO.StreamReader(path))
                {
                    return (T)xs.Deserialize(file);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Carregar um XmlDocumento informando o encoding
        /// </summary>
        /// <param name="xmlDoc">XmlDocument</param>
        /// <param name="newEncoding">Tipo do enconding</param>
        /// <returns>Carregar um XmlDocumento com o encoding informado</returns>
        public static XmlDocument ChangeXmlEncoding(this XmlDocument xmlDoc, string newEncoding)
        {
            if (xmlDoc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
            {
                XmlDeclaration xmlDeclaration = (XmlDeclaration)xmlDoc.FirstChild;
                xmlDeclaration.Encoding = newEncoding;
            }
            return xmlDoc;
        }
    }
}
