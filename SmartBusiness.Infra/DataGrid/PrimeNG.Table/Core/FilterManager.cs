using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using SmartBusiness.Identity.Interfaces;
using SmartBusiness.Infra.DataGrid.PrimeNG.Table.Models;

using static Dapper.DapperExt;

namespace SmartLib.DataGrid.PrimeNG.Table.Core
{
    public class FilterManager 
    {
        private Type currentType ;

        private readonly IDictionary<Type, string> TableNames = new Dictionary<Type, string>();
        private readonly IDictionary<string, string> ColumnNames = new Dictionary<string, string>();
        private IColumnNameResolver _columnNameResolver = new ColumnNameResolver();


        public FilterManager(Type entityType)
        {
            currentType = entityType;
        }

        public IEnumerable<string> GetWhereGlobalFilter(object globalFilter)
        {
            var properties = currentType.GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                var property = properties[i];

                if ( property.PropertyType == globalFilter.GetType())
                {
                    yield return string.Format("{0} LIKE {1} ", GetColumnName(property), $"'%{globalFilter.ToString()}%'");
                }
               
            }
            
        }

        public IEnumerable<string> GetOrderByField(string fieldName)
        {
            string columnaName = string.Empty;

            var properties = currentType.GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                var property = properties[i];

                if (fieldName.Contains(","))
                {
                    var arrFields = fieldName.Split(",");

                    for (int j = 0; j < arrFields.Length; j++)
                    {
                        if (property.Name.ToUpper() == arrFields[j].ToUpper())
                        {
                            columnaName = GetColumnName(property);

                            yield return columnaName;
                        }
                    }
                }
                else
                {
                    if (property.Name.ToUpper() == fieldName.ToUpper())
                    {
                        columnaName = GetColumnName(property);
                        yield return columnaName;
                    }
                }
            }

        }

        private  string GetColumnName(PropertyInfo propertyInfo)
        {
            string columnName, key = string.Format("{0}.{1}", propertyInfo.DeclaringType, propertyInfo.Name);

            if (ColumnNames.TryGetValue(key, out columnName))
                return columnName;

            columnName = _columnNameResolver.ResolveColumnName(propertyInfo);

            ColumnNames[key] = columnName;

            return columnName;
        }

        private IEnumerable<PropertyInfo> GetAllProperties<T>(T entity) where T : class
        {
            if (entity == null) return new PropertyInfo[0];

            return entity.GetType().GetProperties();
        }

        //private static string GetTableName(Type type)
        //{
        //    string tableName;

        //    var tableAttr = type.GetCustomAttributes(true).SingleOrDefault(attr => attr.GetType().Name == "Table") as dynamic;

        //    if (TableNames.TryGetValue(type, out tableName))
        //    {
        //        return tableName;
        //    }

        //    tableName = tableAttr.Name; ;

        //    TableNames[type] = tableName;

        //    return tableName;
        //}
    }

    public class ColumnNameResolver : IColumnNameResolver
    {
        public virtual string ResolveColumnName(PropertyInfo propertyInfo)
        {
            var columnName = Encapsulate(propertyInfo.Name);

            var columnattr = propertyInfo.GetCustomAttributes(true).SingleOrDefault(attr => attr.GetType().Name == typeof(ColumnAttribute).Name) as dynamic;
            if (columnattr != null)
            {
                columnName = Encapsulate(columnattr.Name);
                if (Debugger.IsAttached)
                    Trace.WriteLine(String.Format("Column name for type overridden from {0} to {1}", propertyInfo.Name, columnName));
            }
            return columnName;
        }
    }
}
