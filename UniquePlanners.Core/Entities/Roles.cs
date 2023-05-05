using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Core.Entities.Base;

namespace UniquePlanners.Core.Entities
{
    public class Roles : BaseEntity<int>
    {
        public Roles()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public string RoleName { get; set; } = null!;
        public string? Description { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; } = null!;
    }
}
