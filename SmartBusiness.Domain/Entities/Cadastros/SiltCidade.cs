using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SmartBusiness.Domain.Entities;

namespace SmartBusiness.Domain.Cadastros
{

 
    [Table("silt_cidade")] 
    public class SiltCidade : EntityBase
    {	
        public SiltCidade ()
        {
        }

        [Key]
        [Column("id_cidade")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCidade { get; set; }

        [Column("id_uf")]
        public int IdUf { get; set; }

        [Column("nome_cidade")]
        public string NomeCidade { get; set; }

        [Column("capital")]
        public string Capital { get; set; }

        [Column("id_meso_regiao")]
        public string IdMesoRegiao { get; set; }

        [Column("id_micro_regiao")]
        public string IdMicroRegiao { get; set; }

    }

}
