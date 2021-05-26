using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyCode.NetCoreBoilerplate.Core.Models
{
    [Table("patient")]
    public class Patient
    {
        [Key]
        [Column("patient_no", TypeName = "int(11)")]
        public int PatientNo { get; set; }

        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("email")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Column("cpf")]
        [StringLength(14)]
        public string Cpf { get; set; }

        [Required]
        [Column("birthdate")]
        [StringLength(10)]
        public string Birthdate { get; set; }

        [Required]
        [Column("comorbidity")]
        public bool Comorbidity { get; set; }

        [Required]
        [Column("address")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [Column("district")]
        [StringLength(100)]
        public string District { get; set; }

        [Required]
        [Column("state")]
        [StringLength(100)]
        public string State { get; set; }

        [Required]
        [Column("city")]
        [StringLength(100)]
        public string City { get; set; }
    }
}
