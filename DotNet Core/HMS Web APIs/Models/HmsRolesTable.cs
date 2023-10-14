using System;
using System.Collections.Generic;

namespace HMS_Web_APIs.Models
{
    public partial class HmsRolesTable
    {
        public HmsRolesTable()
        {
            HmsUserRoleMappingTables = new HashSet<HmsUserRoleMappingTable>();
        }

        public int RoleId { get; set; }
        public string Role { get; set; } = null!;

        public virtual ICollection<HmsUserRoleMappingTable> HmsUserRoleMappingTables { get; set; }
    }
}
