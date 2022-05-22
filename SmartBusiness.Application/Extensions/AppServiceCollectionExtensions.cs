using Microsoft.Extensions.DependencyInjection;
using SmartBusiness.AppServices.CtaAcesso;
using SmartBusiness.AppServices.CtaAcesso.Interfaces;
using SmartBusiness.Domain.Entities.CtAcesso;
using SmartBusiness.Identity.Models;
using SmartBusiness.Infra.Repositories.CtAcesso;
using SmartBusiness.Infra.Repositories.Interfaces;

namespace SmartBusiness.AppServices.Extensions
{
    public static class AppServiceCollectionExtensions
    {
      
        public static void AddAppServices(this IServiceCollection services)
        {
            //Cria instancias de Repositorios cada vez que for acessado
            services.AddTransient<IBaseRepository<SiltTokensApi>, SiltTokensApiRepository>();
            services.AddTransient<IBaseRepository<CtaUsuario>, CtaUsuarioRepository>();
            services.AddTransient<IBaseRepository<VwCtaItensMenuGrupo>, VwCtaItensMenuGrupoRepository>();

            //Cria innstacias de Serviços apenas uma vez (primeira solicitação)
            services.AddScoped<ISiltTokensApiService, SiltTokensApiService>();

            services.AddSingleton<ICtaUsuarioService, CtaUsuarioService>();
            
        }
    }
}
