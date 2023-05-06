using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.Base;

namespace UniquePlanners.Application.Dto.UserDto
{
    public class UserSearchObject : BaseSearchObject
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public bool? IncludeRoles { get; set; }
        public bool? IncludePlanners { get; set; }
    }
}
