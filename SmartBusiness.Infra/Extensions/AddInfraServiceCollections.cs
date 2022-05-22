using Microsoft.Extensions.DependencyInjection;
using SmartBusiness.Infra.Repositories;
using SmartBusiness.Infra.Repositories.Interfaces;
using SmartBusiness.Infra.Repositories.Tenants;

namespace SmartBusiness.Infra.Extensions
{
    public static class AddInfraServiceCollections
    {
        /// <summary>
        /// Adiciona os repositorios de SmartBusiness.Infra para injeção de dependencia
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ISiltTenantsRepository,SiltTenantsRepository>();
            
            // services.AddSingleton<ITenat>();
        }
    }
}
