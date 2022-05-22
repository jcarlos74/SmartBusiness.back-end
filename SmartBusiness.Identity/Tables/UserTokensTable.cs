using System.Collections.Generic;
using System.Threading.Tasks;

using Dapper;

using SmartBusiness.Identity.Interfaces;
using SmartBusiness.Identity.Models;

namespace SmartBusiness.Identity.Tables
{
    internal class UserTokensTable
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public UserTokensTable(IDatabaseConnectionFactory databaseConnectionFactory) => _databaseConnectionFactory = databaseConnectionFactory;

        public async Task<IEnumerable<ApplicationUserTokens>> GetTokensAsync(int userId,int idTenant)
        {
            const string command = "SELECT * " +
                                   "FROM cta_usuario_tokens " +
                                   "WHERE id_usuario = @id_usuario AND id_tenant = @id_tenant;";

            using (var sqlConnection = await _databaseConnectionFactory.CreateConnectionAsync())
            {
                return await sqlConnection.QueryAsync<ApplicationUserTokens>(command, new
                {
                    IdUsuario = userId,
                    IdTenant = idTenant
                });
            }
        }
    }
}
