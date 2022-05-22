using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBusiness.Api.Security
{
    public class Token
    {
        /// <summary>
        /// Se True indica que o usuário foi autenticado
        /// </summary>
        public bool Authenticated { get; set; }

        /// <summary>
        /// Data de criação do Token
        /// </summary>
        public string CreationDate { get; set; }

        /// <summary>
        /// Data de expiração do Token
        /// </summary>
        public string Expiration { get; set; }

        /// <summary>
        /// Token de acesso
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Token de atualização
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Se True indica que é o primeiro acesso do usuário
        /// </summary>
        public bool FirstAccess { get; set; }

        public string Message { get; set; }

        public UserInfo UserInfo { get; set; }

        ////public string UserName { get; set; }

        ////public string Email { get; set; }
    }

    public class UserInfo
    {
        public int IdUsuario { get; set; }

        public int? IdColaborador { get; set; }

        public int IdTenant { get; set; }
        
        public string UserName { get; set; }

        public string Email { get; set; }

        public bool Bloqueado { get; set; }

        public int IdEmpresa { get; set; }

        public string RazaoSocialEmpresa { get; set; }

        public string NomeFantasiaEmpresa { get; set; }
    }
}
