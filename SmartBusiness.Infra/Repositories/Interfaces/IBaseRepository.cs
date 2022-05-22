using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SmartBusiness.Domain.Entities;
using SmartBusiness.Domain.Entities.Tenants;
using SmartBusiness.Infra.DataGrid.PrimeNG.Table.Models;


namespace SmartBusiness.Infra.Repositories.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : EntityBase 
    {
        IList<T> ListAll();

        IList<T> List(Expression<Func<T, bool>> where);

        T Find(Expression<Func<T, bool>> where);


        //int? Inserir(TEntidade obj);

        int? Insert(T obj);

        int Update(T obj);

        int Delete(T obj);

        int Delete(Expression<Func<T, bool>> where);

        int Count();

        int Count(Expression<Func<T, bool>> where);

        IEnumerable<T> PagedList(FilterModel filterModel, out int totalResults);

        //Task<IEnumerable<T>> PagedListAsync(SearchRequest searchRequest, out int totalResults);

        T FindBySQL(string sql);

        int GetCurrentTenatId();



    }
}
