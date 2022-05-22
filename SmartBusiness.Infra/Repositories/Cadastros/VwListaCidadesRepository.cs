
using DapperExt;

using SmartBusiness.Domain.Entities.Cadastros;

namespace SmartBusiness.Infra.Repositories.Cadastros
{
    public class VwListaCidadesRepository : BaseRepository<VwListaCidades> //, IVwListaCidades
    {
        public VwListaCidadesRepository(IDapperDbContext context) : base(context)
        {
        }
    }
     
}
