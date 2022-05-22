using DapperExt;
using SmartBusiness.Identity.Models;

namespace SmartBusiness.Infra.Repositories.CtAcesso
{
    public class SiltTokensApiRepository : BaseRepository<SiltTokensApi>//, ISiltTokensApi
    {
        public SiltTokensApiRepository(IDapperDbContext context) : base(context)
        {
        }
    }
}
