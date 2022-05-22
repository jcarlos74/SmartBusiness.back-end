
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using SmartBusiness.Identity.ConnectionFactories;
using SmartBusiness.Identity.Interfaces;
using SmartBusiness.Identity.Models;
using SmartBusiness.Identity.Stores;

namespace Identity.Dapper.Extensions
{

    public static class IdentityBuilderExtensions
    {
        /// <summary>
        /// Adiciona implementação Dapper de armazenamentos de identidade do ASP.NET Core.
        /// </summary>
        public static IdentityBuilder AddDapperIdentityStores(this IdentityBuilder builder,  string connectionString)
        {
            AddStores(builder.Services, connectionString);
            return builder;
        }

        private static void AddStores(IServiceCollection services, string connectionString)
        {

            services.AddScoped<IUserStore<ApplicationUser>, UserStore>();
            services.AddScoped<IRoleStore<ApplicationRole>, RoleStore>();
            services.AddScoped<IDatabaseConnectionFactory>(provider => new PostgresConnectionFactory(connectionString));
        }
    }
}
