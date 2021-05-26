using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyCode.NetCoreBoilerplate.Core.Models
{
    [Table("vaccine")]
    public class Vaccine
    {
        [Key]
        [Column("vaccine_no", TypeName = "int(11)")]
        public int VaccineNo { get; set; }

        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Column("manufacturer")]
        [StringLength(100)]
        public string Manufacturer { get; set; }

        [Required]
        [Column("birthdate")]
        [StringLength(10)]
        public string Birthdate { get; set; }

        [Required]
        [Column("batch")]
        public bool Batch { get; set; }

        [Required]
        [Column("dueDate")]
        [StringLength(100)]
        public string DueDate { get; set; }

        [Required]
        [Column("numberOfDoses")]
        [StringLength(100)]
        public string NumberOfDoses { get; set; }

        [Required]
        [Column("intervalBetweenDoses")]
        [StringLength(100)]
        public string IntervalBetweenDoses { get; set; }
    }
}
