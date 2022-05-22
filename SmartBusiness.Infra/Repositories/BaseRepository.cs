using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Dapper;
using DapperExt;
using Npgsql;
using SmartBusiness.Domain.Entities;
using SmartBusiness.Infra.Data;
using SmartBusiness.Infra.DataGrid.PrimeNG.Table.Models;
using SmartBusiness.Infra.Extensions;
using SmartBusiness.Infra.Repositories.Interfaces;

using SmartLib.DataGrid.PrimeNG.Table.Core;


namespace SmartBusiness.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly string _connectionString;
        private readonly string _schema;
        private readonly int _idTenant;
        private readonly IDbSession _session;
        private readonly IDapperDbContext _context;
        private static readonly IDictionary<Type, string> TableNames = new Dictionary<Type, string>();

        public BaseRepository(IDapperDbContext context)
        {
            _context = context;

            _connectionString = _context.GetConnectionString();

            // SetTenant(_idTenant);
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public int Delete(T obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
//throw new NotImplementedException();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _context.Get<T>(where);
        }

        public T FindBySQL(string sql)
        {
            throw new NotImplementedException();
        }

       

        public int Update(T obj)
        {
            throw new NotImplementedException();
        }

        public IList<T> List(Expression<Func<T, bool>> where)
        {
            try
            {
                return _context.Query<T>( where).AsList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IList<T> ListAll()
        {
            try
            {
                return _context.GetList<T>().AsList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int GetCurrentTenatId()
        {
            return _idTenant;
        }

        private void SetTenant(int idTenant)
        {
            try
            {
                if (_session != null && idTenant > 0)
                {
                    var sql = $"set app.current_tenant = '{idTenant}';";

                    _session.Connection.Execute(sql);
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public int? Insert(T obj, string sequenceName="")
        {
            return _context.Insert(obj, sequenceName);
        }

        public IEnumerable<T> PagedList(FilterModel filterModel, out int totalResults)
        {
            var currentType = typeof(T);

            IEnumerable<T> result = null;
           

            try
            {
                var filterManager = new FilterManager(currentType);

                var sqlWhere = string.Empty;
                var orderBy = string.Empty;

                if (!filterModel.globalFilter.IsNullOrEmpty())
                {
                    var whereClause = string.Join("OR", filterManager.GetWhereGlobalFilter(filterModel.globalFilter));

                    if (!string.IsNullOrEmpty(whereClause))
                    {
                        sqlWhere = $"Where {whereClause} ";
                    }
                }

                if (!filterModel.SortField.IsNullOrEmpty())
                {

                    orderBy = string.Join(",", filterManager.GetOrderByField(filterModel.SortField));
                    //!columnSort.IsNullOrEmpty() ? columnSort : string.Empty;
                }

                //if (!string.IsNullOrEmpty(searchRequest.Search?.Value))
                //{
                //    var whereClause = string.Join("OR", GetSearchClause(searchRequest));

                //    if (!string.IsNullOrEmpty(whereClause))
                //    {

                //        sqlWhere = $"Where {whereClause} ";
                //    }
                //}
                //else if (searchRequest.Filter?.Count > 0)
                //{

                //    var condicao = GetFilterClause(searchRequest);

                //    if (condicao != null && condicao.Any())
                //    {
                //        var whereClause = string.Join(" OR ", condicao);

                //        if (!string.IsNullOrEmpty(whereClause))
                //        {
                //            sqlWhere = $"Where {whereClause} ";
                //        }
                //    }
                //}

                ////if (string.IsNullOrEmpty(sqlWhere))
                ////{
                ////    sqlWhere = $"Where id_tenant = {_idTenant}";
                ////}
                ////else
                ////{
                ////    sqlWhere += $" and id_tenant = {_idTenant}";
                ////}

                //var orderBy = string.Empty;

                //if (searchRequest.Order != null)
                //{
                //    orderBy = "ORDER BY " + string.Join(",", GetOrderByClause(searchRequest));
                //}

                var startRowIndex = filterModel.First == 0 ? 1 : filterModel.First;
                var pageSize = filterModel.Rows;

                var pageNumber = 1;

                if (filterModel.First > 0)
                {
                    pageNumber = (startRowIndex + pageSize - 1) / pageSize;
                }

                using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
                {


                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    totalResults = connection.RecordCount<T>(sqlWhere);

                    
                    result = connection.GetListPaged<T>(pageNumber, filterModel.Rows, sqlWhere, orderBy);

                    //Aguarda de 20 a 25 ms para liberar a conexão (bug do Npgsql)
                    for (int i = 1; i < 50; i++)
                    {
                        if (!connection.FullState.HasFlag(System.Data.ConnectionState.Fetching))
                            break;
                        Thread.Sleep(i * 10);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public Task<IEnumerable<T>> PagedListAsync(SearchRequest searchRequest, out int totalResults)
        //{
        //    Task<IEnumerable<T>> result = null;

        //    try
        //    {

        //        var sqlWhere = string.Empty;

        //        if (!string.IsNullOrEmpty(searchRequest.Search?.Value))
        //        {
        //            var whereClause = string.Join("OR", GetSearchClause(searchRequest));

        //            if (!string.IsNullOrEmpty(whereClause))
        //            {

        //                sqlWhere = $"Where {whereClause} ";
        //            }
        //        }
        //        else if (searchRequest.Filter?.Count > 0)
        //        {

        //            var condicao = GetFilterClause(searchRequest);

        //            if (condicao != null && condicao.Any())
        //            {
        //                var whereClause = string.Join(" OR ", condicao);

        //                if (!string.IsNullOrEmpty(whereClause))
        //                {
        //                    sqlWhere = $"Where {whereClause} ";
        //                }
        //            }
        //        }

        //        var orderBy = string.Empty;

        //        if (searchRequest.Order != null)
        //        {
        //            orderBy = "ORDER BY " + string.Join(",", GetOrderByClause(searchRequest));
        //        }

        //        var startRowIndex = searchRequest.Start;
        //        var pageSize = searchRequest.Length;

        //        var pageNumber = 0;

        //        if (searchRequest.Start > 0)
        //        {
        //            pageNumber = (startRowIndex + pageSize - 1) / pageSize;
        //        }


        //        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        //        {

        //            if (connection.State == System.Data.ConnectionState.Closed)
        //            {
        //                connection.Open();
        //            }

        //            if (_idTenant > 0)
        //            {
        //                var sql = $"set app.current_tenant = '{_idTenant}';";

        //                connection.Execute(sql);
        //            }

        //            totalResults = connection.RecordCount<T>(sqlWhere);

        //            result = connection.GetListPagedAsync<T>(pageNumber, pageSize, sqlWhere, null);

        //            Aguarda de 20 a 25 ms para liberar a conexão(bug do Npgsql)
        //            for (int i = 1; i < 50; i++)
        //            {
        //                if (!connection.FullState.HasFlag(System.Data.ConnectionState.Fetching))
        //                    break;
        //                Thread.Sleep(i * 10);
        //            }
        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        //private static IEnumerable<string> GetOrderByClause(SearchRequest searchRequest)
        //{

        //    foreach (var column in searchRequest.Order)
        //    {
        //        var order = column.Descending ? "DESC" : "ASC";

        //        yield return string.Format("{0} {1}", column.Column.ToUnderscoreCase(), order);
        //    }
        //}

        //private static IEnumerable<string> GetSearchClause(SearchRequest searchRequest)
        //{

        //    foreach (var column in searchRequest.Columns)
        //    {
        //        if (column.Searchable)
        //        {
        //            yield return string.Format("{0} LIKE {1} ", column.Name.ToUnderscoreCase(), $"'%{searchRequest.Search.Value}%'");
        //        }
        //    }

        //}

       

        //private static IEnumerable<string> GetFilterClause(SearchRequest searchRequest)
        //{

        //    object[] arrFilter = searchRequest.Filter.OfType<object>().ToArray();

        //    for (int i = 0; i < arrFilter.Length; i++)
        //    {

        //        var item = arrFilter[i];

        //        if (item != null && item.GetType() != typeof(string))
        //        {
        //            object[] arrFiltro = null;

        //            try
        //            {
        //                arrFiltro = ((IEnumerable)item).Cast<object>().Select(x => x).ToArray();
        //            }
        //            catch (Exception)
        //            {

        //            }


        //            if (arrFiltro != null)
        //            {
        //                var coluna = arrFiltro[0]?.ToString();

        //                var condicao = arrFiltro[1]?.ToString();

        //                var valor = arrFiltro[2]?.ToString();

        //                if (condicao == "startswith")
        //                {
        //                    yield return $"({coluna.ToUnderscoreCase()} LIKE '{valor}%')";
        //                }
        //                else
        //                {
        //                    yield return $"({coluna.ToUnderscoreCase()} LIKE '%{valor}%')";
        //                }
        //            }
        //            else
        //            {
        //                yield return string.Empty;
        //            }

        //        }
        //    }

        //}

        public int? Insert(T obj)
        {
            return _context.Insert(obj);
        }
    }
}
