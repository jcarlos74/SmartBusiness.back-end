using SqlKata;

namespace SmartBusiness.Identity.Models
{
    public class ApplicationUserLogins
    {
        public ApplicationUserLogins()
        {
        }

        [Key]
        [Column("provedor_login")]
        public string ProvedorLogin { get; set; }

        [Key]
        [Column("chave_provedor")]
        public string ChaveProvedor { get; set; }

        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Column("id_tenant")]
        public int IdTenant { get; set; }

        [Column("nome_provedor")]
        public string NomeProvedor { get; set; }

    }
}
