using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    public class PatientMedicamentConfig:IEntityTypeConfiguration<PatientMedicament>
    {
        public void Configure(EntityTypeBuilder<PatientMedicament> builder)
        {
          entity.HasKey(e => new { e.PatientId, e.MedicamentId });

                entity.HasOne(e => e.Medicament)
                   .WithMany(e => e.Prescriptions)
                   .HasForeignKey(e => e.MedicamentId);

                entity.HasOne(e => e.Patient)
                  .WithMany(e => e.Prescriptions)
                  .HasForeignKey(e => e.PatientId);
        }
    }
}
