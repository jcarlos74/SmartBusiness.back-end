using System.Collections.Generic;
using System.Linq.Expressions;
using System;

using SmartBusiness.Domain.Entities.CtAcesso;

namespace SmartBusiness.AppServices.CtaAcesso.Interfaces
{
    public interface ICtaUsuarioService : IService<CtaUsuario>
    {
        List<VwCtaItensMenuGrupo> ListaItensMenu(Expression<Func<VwCtaItensMenuGrupo, bool>> where);
    }
}
