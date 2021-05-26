using HappyCode.NetCoreBoilerplate.Core.Dtos;
using HappyCode.NetCoreBoilerplate.Core.Models;

namespace HappyCode.NetCoreBoilerplate.Core.Extensions
{
    internal static class VaccineExtensions
    {
        public static VaccineDto MapToDto(this Vaccine source)
        {
            return new VaccineDto
            {
                Id = source.VaccineNo,
                Name = source.Name,
                Manufacturer = source.Manufacturer,
                Batch = source.Batch,
                DueDate = source.DueDate,
                NumberOfDoses = source.NumberOfDoses,
                IntervalBetweenDoses = source.IntervalBetweenDoses,
            };
        }
    }
}
