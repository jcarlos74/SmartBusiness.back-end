using DapperExt;
using SmartBusiness.Domain.Entities.CtAcesso;

namespace SmartBusiness.Infra.Repositories.CtAcesso
{

    public class VwCtaItensMenuGrupoRepository : BaseRepository<VwCtaItensMenuGrupo>//, IVwCtaItensMenuGrupo
    {
        public VwCtaItensMenuGrupoRepository(IDapperDbContext context) : base(context)
        {
        }

		
    }
}