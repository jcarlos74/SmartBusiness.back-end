using DapperExt;
using SmartBusiness.Domain.Entities.CtAcesso;

namespace SmartBusiness.Infra.Repositories.CtAcesso
{
    public class VwListaUsuariosRepository : BaseRepository<VwListaUsuarios>
    {
        public VwListaUsuariosRepository(IDapperDbContext context) : base(context)
        {
        }
    }
}
