using System;
using HappyCode.NetCoreBoilerplate.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HappyCode.NetCoreBoilerplate.Core
{
    public partial class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Patient> Patient { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasIndex(e => e.PatientNo)
                    .HasDatabaseName("patient_no");
            });
        }
    }
}