using System;
using System.Reflection;

namespace Aplicacao
{
    /// <summary>
    /// Calsse para informar valores nas propriedades nos documento fiscais
    /// </summary>
    public static class InformaValor
    {
        /// <summary>
        /// Informar um valor na propriedade no documento fiscal
        /// </summary>
        /// <param name="obj">Objeto que será manipulado</param>
        /// <param name="campo">Nome do campo que vai receber o valor</param>
        /// <param name="valor">Vaor que será informado no campo</param>
        public static void SetarValor(this object obj, string campo, string valor)
        {
            try
            {
                obj.GetType().GetProperty(campo, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).SetValue(obj, valor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
