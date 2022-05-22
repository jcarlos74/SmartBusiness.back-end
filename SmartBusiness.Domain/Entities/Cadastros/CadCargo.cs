using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBusiness.Domain.Entities.CtAcesso
{


    [Table("cad_cargo")] 
   public class CadCargo : EntityBase
    {	
      public CadCargo ()
      {
      }

      [Key]
      [Column("id_cargo")]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCargo { get; set; }

      [Column("id_tenant")]
      public int IdTenant { get; set; }

      [Column("nome_cargo")]
      public string NomeCargo { get; set; }

   }

}
