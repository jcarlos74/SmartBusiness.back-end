using DapperExt;
using SmartBusiness.Domain.Entities.CtAcesso;

namespace SmartBusiness.Infra.Repositories.Cadastros
{
    public class CadCargoRepository : BaseRepository<CadCargo>
    {
        public CadCargoRepository(IDapperDbContext context) : base(context)
        {
        }
    }
}
