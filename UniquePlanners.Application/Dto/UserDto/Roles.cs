using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.Base;

namespace UniquePlanners.Application.Services.UserService.Dto
{
    public class Roles : BaseDto<int>
    {
        public string? RoleName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<UserRoles>? UserRoles { get; set; }
    }
}
