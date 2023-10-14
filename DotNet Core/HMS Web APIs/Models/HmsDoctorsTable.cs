using System;
using System.Collections.Generic;

namespace HMS_Web_APIs.Models
{
    public partial class HmsDoctorsTable
    {
        public HmsDoctorsTable()
        {
            HmsProviderAvailabilityTables = new HashSet<HmsProviderAvailabilityTable>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = null!;
        public string DoctorPhone { get; set; } = null!;
        public DateTime DoctorDob { get; set; }
        public string DoctorEmail { get; set; } = null!;
        public string DoctorPassword { get; set; } = null!;
        public string Gender { get; set; } = null!;
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
