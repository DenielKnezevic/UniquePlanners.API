using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Core.Entities.Base;

namespace UniquePlanners.Core.Entities
{
    public class UserRoles : BaseEntity<int>
    {
        public int UserId { get; set; } 
        public int RoleId { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual Roles Role { get; set; } = null!;
    }
}
