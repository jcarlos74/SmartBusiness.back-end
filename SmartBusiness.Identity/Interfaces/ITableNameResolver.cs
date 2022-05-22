using System;

namespace SmartBusiness.Identity.Interfaces
{
    public interface ITableNameResolver
    {
        string ResolveTableName(Type type);
    }
}
