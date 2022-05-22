using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBusiness.Domain.Entities.CtAcesso
{


    [Table("cad_departamento")] 
   public class CadDepartamento : EntityBase
    {	
      public CadDepartamento ()
      {
      }

      [Key]
      [Column("id_departamento")]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int IdDepartamento { get; set; }

      [Column("id_tenant")]
      public int IdTenant { get; set; }

      [Column("nome_departamento")]
      public string NomeDepartamento { get; set; }

   }

}
