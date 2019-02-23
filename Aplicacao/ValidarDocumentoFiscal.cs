using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace Aplicacao
{
    /// <summary>
    /// Classe para validar o Squema de um documento fiscal
    /// </summary>
    public class ValidarDocumentoFiscal
    {
        bool falhou;
        /// <summary>
        /// Caminho onde se encontra o arquivo XSD
        /// </summary>
        public string CaminhoSquemaXSD { get; private set; }
        /// <summary>
        /// Erros que foram encontrado no xml
        /// </summary>
        public string Erros { get; private set; }

        /// <summary>
        /// informar o caminho do arquifo XSD
        /// </summary>
        /// <param name="caminho"></param>
        public void SetarSquemaXSD(string caminho)
        {
            CaminhoSquemaXSD = caminho;
        }

        /// <summary>
        /// Validar o xml se está dentro do squema XSD
        /// </summary>
        /// <param name="caminhoXML">Caminho onde se encontra o documento xml</param>
        /// <returns>Retonra true se a validação está dentro do Squema XSD, caso contrário retora false</returns>
        public bool ValidarDocumentoXML(string caminhoXML)
        {
            try
            {
                Erros = "";

                if (!string.IsNullOrWhiteSpace(CaminhoSquemaXSD) && File.Exists(CaminhoSquemaXSD))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.ValidationType = ValidationType.Schema;
                    XmlSchemaSet schemas = new XmlSchemaSet();
                    settings.Schemas = schemas;
                    schemas.Add(null, CaminhoSquemaXSD);
                    settings.ValidationEventHandler += ValidationEventHandler;
                    XmlReader validator = XmlReader.Create(caminhoXML, settings);
                    falhou = false;

                    try
                    {
                        while (validator.Read()) { }
                    }
                    catch (XmlException err)
                    {
                        Erros = $"Ocorreu um erro critico durante a validacao XML. {err.Message}";
                        falhou = true;
                    }
                    finally
                    {
                        validator.Close();
                    }
                    return !falhou;
                }

                return true;
            }
            catch (Exception ex)
            {
                Erros = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Informa os erros de validação caso for encontrado
        /// </summary>
        /// <param name="sender">Objeto sender do evento</param>
        /// <param name="args">Argumentos do evento</param>
        private void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            falhou = true;
            Erros = "\nErros da validação : " + args.Message;
        }
    }
}
