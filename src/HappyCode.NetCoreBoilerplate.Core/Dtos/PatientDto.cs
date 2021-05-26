using System;
namespace HappyCode.NetCoreBoilerplate.Core.Dtos
{
    public class PatientDto
    {
        public Guid Id { get;  set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public string Birthdate { get; set; }

        public bool Comorbidity { get; set; }

        public string Address { get; set; }

        public string District { get; set; }

        public string State { get; set; }

        public string City { get; set; }
    }
}
