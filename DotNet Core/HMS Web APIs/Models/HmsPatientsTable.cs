using System;
using System.Collections.Generic;

namespace HMS_Web_APIs.Models
{
    public partial class HmsPatientsTable
    {
        public HmsPatientsTable()
        {
            HmsProviderAvailabilityTables = new HashSet<HmsProviderAvailabilityTable>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!;
        public DateTime PatientDob { get; set; }
        public string PatientPhone { get; set; } = null!;
        public string PatientEmail { get; set; } = null!;
        public string PatientPassword { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string FatherName { get; set; } = null!;
        public string MaritalStatus { get; set; } = null!;
        public string? BloodGroup { get; set; }
        public string? Symptoms { get; set; }
        public string? Diagnosis { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<HmsProviderAvailabilityTable> HmsProviderAvailabilityTables { get; set; }
    }
}
