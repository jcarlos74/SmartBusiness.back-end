using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SmartBusiness.Infra.Repositories.Interfaces;
using SmartBusiness.Domain.Cadastros;

namespace SmartBusiness.AppServices.Cadastro
{
    public class CidadeService : ISiltCidadeService
    {
        private readonly IBaseRepository<SiltCidade> _siltCidade;
    
        public CidadeService(IBaseRepository<SiltCidade> siltCidade)
        {
            _siltCidade = siltCidade;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<SiltCidade, bool>> where)
        {
            throw new NotImplementedException();
        }

        public int Delete(SiltCidade obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Expression<Func<SiltCidade, bool>> where)
        {
            throw new NotImplementedException();
        }

        public SiltCidade Find(Expression<Func<SiltCidade, bool>> where)
        {
            throw new NotImplementedException();
        }

        public SiltCidade FindBySQL(string sql)
        {
            throw new NotImplementedException();
        }

        public int GetCurrentTenatId()
        {
            throw new NotImplementedException();
        }

        public int? Insert(SiltCidade obj)
        {
            throw new NotImplementedException();
        }

        public IList<SiltCidade> List(Expression<Func<SiltCidade, bool>> where)
        {
            return _siltCidade.List(where);
        }

        public int Update(SiltCidade obj)
        {
            throw new NotImplementedException();
        }
    }
}
