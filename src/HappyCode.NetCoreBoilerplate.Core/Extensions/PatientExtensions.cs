using System;
using HappyCode.NetCoreBoilerplate.Core.Dtos;

namespace HappyCode.NetCoreBoilerplate.Core.Extensions
{
    internal static class PatientExtensions
    {
        public static PatientDto MapToDto(this Patient source)
        {
            return new PatientDto
            {
                Id = source.PatientNo,
                Name = source.Name,
                Email = source.Email,
                Birthdate = source.Birthdate,
                Comorbidity = source.Comorbidity,
                Address = source.Address,
                District = source.District,
                State = source.State,
                City = source.City
            };
        }
    }
}
