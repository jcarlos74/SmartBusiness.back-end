
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBusiness.Domain.Entities.Cadastros
{

 
   [Table("VW_LISTA_CIDADES")] 
   public class VwListaCidades : EntityBase
   {	
      public VwListaCidades ()
      {
      }

      [Key]
      [Column("id_cidade")]
      public int? IdCidade { get; set; }

      [Column("id_uf")]
      public int? IdUf { get; set; }

      [Column("nome_uf")]
      public string NomeUf { get; set; }

      [Column("id_meso_regiao")]
      public string IdMesoRegiao { get; set; }

      [Column("macro_regiao")]
      public string MacroRegiao { get; set; }

      [Column("id_micro_regiao")]
      public string IdMicroRegiao { get; set; }

      [Column("micro_regiao")]
      public string MicroRegiao { get; set; }

      [Column("nome_cidade")]
      public string NomeCidade { get; set; }

   }

}
