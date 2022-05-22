using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBusiness.Domain.Entities.CtAcesso
{
    
   [Table("vw_lista_usuarios")] 
   public class VwListaUsuarios : EntityBase
   {	
      public VwListaUsuarios ()
      {
      }

      [Key]
      [Column("id_usuario")]
      public int IdUsuario { get; set; }

      [Column("id_pessoa")]
      public int IdPessoa { get; set; }

      [Column("id_tenant")]
      public int IdTenant { get; set; }

      [Column("id_colaborador")]
      public int IdColaborador { get; set; }

      [Column("bloqueado")]
      public bool Bloqueado { get; set; }

      [Column("nome_usuario")]
      public string NomeUsuario { get; set; }

      [Column("nome_completo")]
      public string NomeCompleto { get; set; }

      [Column("email")]
      public string Email { get; set; }

      [Column("telefone")]
      public string Telefone { get; set; }

   }

}
