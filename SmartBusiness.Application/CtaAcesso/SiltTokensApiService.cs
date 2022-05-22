﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SmartBusiness.AppServices.CtaAcesso.Interfaces;
using SmartBusiness.Identity.Models;
using SmartBusiness.Infra.Extensions;
using SmartBusiness.Infra.Repositories.Interfaces;

namespace SmartBusiness.AppServices.CtaAcesso
{
    public class SiltTokensApiService : ISiltTokensApiService
    {

        private readonly IBaseRepository<SiltTokensApi>  _tokensApi;

        public SiltTokensApiService(IBaseRepository<SiltTokensApi> tokensApi)
        {
            _tokensApi = tokensApi;
        }

        public int Count()
        {
            return _tokensApi.Count();
        }

        public int Count(Expression<Func<SiltTokensApi, bool>> where)
        {
            throw new NotImplementedException();
        }

        public int Delete(SiltTokensApi obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Expression<Func<SiltTokensApi, bool>> where)
        {
            throw new NotImplementedException();
        }

        public SiltTokensApi Find(Expression<Func<SiltTokensApi, bool>> where)
        {
            throw new NotImplementedException();
        }

        public SiltTokensApi FindBySQL(string sql)
        {
            throw new NotImplementedException();
        }

        public int GetCurrentTenatId()
        {
            throw new NotImplementedException();
        }

        public int? Insert(SiltTokensApi obj)
        {

            return _tokensApi.Insert(obj);
        }

        public IList<SiltTokensApi> List(Expression<Func<SiltTokensApi, bool>> where)
        {
            return _tokensApi.List(where);
        }

        public bool RevokeToken(int idUsuario, string refreshToken, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public void StoreRefreshToken(int idUsuario, string ipAddress, string oldRefreshToken, string newRefreshToken, string dataCriacao, string dataExpiracao)
        {
            throw new NotImplementedException();
        }

        public void StoreToken(int idUsuario, string ipAddress, string refreshToken, string dataCriacao, string dataExpiracao)
        {

            var tokenUser = new SiltTokensApi()
            {
                IdUsuario = idUsuario,
                RefreshToken = refreshToken,
                DataCriacao = dataCriacao.ToDateTime(),
                CriadoPeloIp = ipAddress,
                ExpiraEm = dataExpiracao.ToDateTime(),
                FoiExpirado = false,
                Revogado = false,
                Ativo = true
            };

            this.Insert(tokenUser);

        }

        public int Update(SiltTokensApi obj)
        {
            return _tokensApi.Update(obj);
        }

    }
}
