using System;
using System.Collections.Generic;

namespace HMS_Web_APIs.Models
{
    public partial class HmsLoginTable
    {
        public HmsLoginTable()
        {
            HmsUserRoleMappingTables = new HashSet<HmsUserRoleMappingTable>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserPhone { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public int? PatientIdInPatientTable { get; set; }
        public int? DoctorIdInDoctorTable { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<HmsUserRoleMappingTable> HmsUserRoleMappingTables { get; set; }
    }
}
