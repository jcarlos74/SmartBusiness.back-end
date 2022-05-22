using System.Threading.Tasks;
using DapperExt;
using Microsoft.AspNetCore.Http;
using SaasKit.Multitenancy;
using SmartBusiness.Domain.Entities.Tenants;
using SmartBusiness.Identity.Models;
using SmartBusiness.Infra.Extensions;
using SmartBusiness.Infra.Repositories.Tenants;

namespace SmartBusiness.Api.Resolvers
{
    public class TenantResolver : ITenantResolver<ApplicationTenant>
    {
        private readonly IDapperDbContext _dbContext;
        private readonly ISiltTenantsRepository _tenantRepository;

        public TenantResolver(ISiltTenantsRepository tenantRepository, IDapperDbContext dapperDbContext)
        {
            _tenantRepository = tenantRepository;
            _dbContext = dapperDbContext;
        }

        public Task<TenantContext<ApplicationTenant>> ResolveAsync(HttpContext context)
        {
            TenantContext<ApplicationTenant> tenantContext = null;

            var hostName = context.Request.Host.Value.ToLower();

            if (hostName.Contains(":")) hostName = hostName.Substring(0, hostName.IndexOf(":"));

            if (_tenantRepository != null)
            {
                hostName = hostName.ClearInjection();

                var tenant = _tenantRepository.Find(t => t.SubDominio == hostName);

                if (tenant != null)
                {
                    _tenantRepository.SetCurrentTenant(tenant.IdTenant);

                    var appTenant = new ApplicationTenant()
                    {
                        IdTenant = tenant.IdTenant,
                        RazaoSocial = tenant.RazaoSocial,
                        Bloqueado = tenant.Bloqueado,
                        Bairro = tenant.Bairro,
                    };

                    tenantContext = new TenantContext<ApplicationTenant>(appTenant);
                }
            }

            return Task.FromResult(tenantContext);
        }
    }
}