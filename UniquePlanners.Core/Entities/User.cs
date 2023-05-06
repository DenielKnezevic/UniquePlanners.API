using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Core.Entities.Base;

namespace UniquePlanners.Core.Entities
{
    public class User : BaseEntity<int>
    {
        public User()
        {
            UserRoles = new HashSet<UserRoles>();
            Planners = new HashSet<Planner>();
        }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DayOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public virtual ICollection<Planner> Planners { get; set; } = null!;
        public virtual ICollection<UserRoles> UserRoles { get; set; } = null!;
    }
}
