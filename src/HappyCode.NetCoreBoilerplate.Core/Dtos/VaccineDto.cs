using System;
namespace HappyCode.NetCoreBoilerplate.Core.Dtos
{
    public class VaccineDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string Batch { get; set; }

        public string DueDate { get; set; }

        public int NumberOfDoses { get; set; }

        public int IntervalBetweenDoses { get; set; }
    }
}
