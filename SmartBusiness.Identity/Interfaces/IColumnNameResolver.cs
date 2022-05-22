using System.Reflection;

namespace SmartBusiness.Identity.Interfaces
{
    public interface IColumnNameResolver
    {
        string ResolveColumnName(PropertyInfo propertyInfo);
    }
}
