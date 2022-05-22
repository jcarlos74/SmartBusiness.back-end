using DapperExt;
using SmartBusiness.Domain.Cadastros;

namespace SmartBusiness.Infra.Repositories.Cadastros
{
    public class SiltCidadeRepository : BaseRepository<SiltCidade>
    {
        public SiltCidadeRepository(IDapperDbContext context) : base(context)
        {
        }
    }

}
