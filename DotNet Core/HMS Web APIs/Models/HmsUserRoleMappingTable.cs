using System;
using System.Collections.Generic;

namespace HMS_Web_APIs.Models
{
    public partial class HmsUserRoleMappingTable
    {
        public int UserRoleMapId { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }

        public virtual HmsRolesTable? Role { get; set; }
        public virtual HmsLoginTable? User { get; set; }
    }
}
