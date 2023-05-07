using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.Base;
using UniquePlanners.Application.Dto.PlannerDto;
using UniquePlanners.Application.Services.PlannerService;

namespace UniquePlanners.Application.Services.UserService.Dto
{
    public class User : BaseDto<int>
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public DateTime DayOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Username { get; set; }
        public virtual ICollection<Planner>? Planners { get; set; }
        public virtual ICollection<UserRoles>? UserRoles { get; set; }
    }
}
