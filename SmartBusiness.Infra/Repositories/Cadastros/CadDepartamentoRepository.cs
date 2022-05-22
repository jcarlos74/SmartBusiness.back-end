using DapperExt;
using SmartBusiness.Domain.Entities.CtAcesso;

namespace SmartBusiness.Infra.Repositories.Cadastros
{
    public class CadDepartamentoRepository : BaseRepository<CadCargo>
    {
        public CadDepartamentoRepository(IDapperDbContext context) : base(context)
        {
        }
    }
}
