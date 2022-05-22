using System;

namespace SmartBusiness.Identity.Extensions
{
    internal static class ObjectExtensions
    {
        internal static void ThrowIfNull<T>(this T @object, string paramName)
        {
            if (@object == null)
            {
                throw new ArgumentNullException(paramName, $"O parâmetro {paramName} não pode ser nulo.");
            }
        }
    }
}
