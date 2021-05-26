using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyCode.NetCoreBoilerplate.Core.Models
{
    [Table("doses")]
    public class Doses
    {
        [Key]
        [Column("doses_no", TypeName = "char(14)")]
        public string DosesNo { get; set; }

        [Required]
        [Column("application_date")]
        [StringLength(10)]
        public string ApplicationDate { get; set; }

        [Required]
        [Column("dose_applied")]
        [StringLength(10)]
        public string DoseApplied { get; set; }

        [ForeignKey("PatientId")]
        public Guid PatientNameId { get; set; }

        [ForeignKey("VaccineId")]
        public Guid VaccineNameId { get; set; }
    }
}
