﻿using SqlKata;

namespace SmartBusiness.Identity.Models
{
    public class ApplicationUserClaims
    {
        public ApplicationUserClaims()
        {
        }

        [Key]
        [Column("id_usuario_claim")]
        [Ignore]
        public int IdUsuarioClaim { get; set; }

        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Column("id_tenant")]
        public int IdTenant { get; set; }

        [Column("claim_type")]
        public string ClaimType { get; set; }

        [Column("claim_value")]
        public string ClaimValue { get; set; }

    }
}
