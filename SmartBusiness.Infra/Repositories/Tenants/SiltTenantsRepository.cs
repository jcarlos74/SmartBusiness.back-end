
using DapperExt;
using SmartBusiness.Domain.Entities.Tenants;
using SmartBusiness.Infra.Repositories.Interfaces;

namespace SmartBusiness.Infra.Repositories.Tenants
{
    public interface ISiltTenantsRepository : IBaseRepository<SiltTenants>
    {
        
        void SetCurrentTenant(int idTenant);
    }

    public class SiltTenantsRepository : BaseRepository<SiltTenants>, ISiltTenantsRepository
    {
        private readonly IDapperDbContext _context;

        public SiltTenantsRepository(IDapperDbContext context) : base(context)
        {
            _context = context;
        }
        
        public void SetCurrentTenant(int idTenant)
        {

            try
            {

                _context.Execute($"set app.current_tenant = '{idTenant}';");
                
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

}
