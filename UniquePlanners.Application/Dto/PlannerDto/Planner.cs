using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.Base;
using UniquePlanners.Application.Dto.PlannerCoversDto;
using UniquePlanners.Application.Services.UserService.Dto;

namespace UniquePlanners.Application.Dto.PlannerDto
{
    public class Planner : BaseDto<int>
    {
        public int UserId { get; set; }
        public string? Name { get; set; } 
        public double? Price { get; set; }
        public virtual User? User { get; set; } 
        public virtual ICollection<PlannerCovers>? PlannerCovers { get; set; } 
    }
}
