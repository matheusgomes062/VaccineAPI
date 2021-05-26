using System;
using System.ComponentModel.DataAnnotations;

namespace HappyCode.NetCoreBoilerplate.Core.Dtos
{
    public class PatientPostDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Birthdate { get; set; }
        [Required]
        public bool Comorbidity { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
    }
}
