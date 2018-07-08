using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Prescriptions=new HashSet<PatientMedicament>();
            this.Diagnoses=new HashSet<Diagnose>();
            this.Visitations=new HashSet<Visitation>();
        }
        [Key]
        public int PatientId { get; set; }

        //[MaxLength(50)]
        public string FirstName { get; set; }

        //[StringLength(30, MinimumLength = 30)]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; }

        public ICollection<Visitation> Visitations { get; set; }

    }
}
