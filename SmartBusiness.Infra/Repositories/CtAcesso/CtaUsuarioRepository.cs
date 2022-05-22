using DapperExt;
using SmartBusiness.Domain.Entities.CtAcesso;

namespace SmartBusiness.Infra.Repositories.CtAcesso
{
    public class CtaUsuarioRepository : BaseRepository<CtaUsuario>//, ICtaUsuario
    {
        public CtaUsuarioRepository(IDapperDbContext context) : base(context)
        {
        }
    }

}
