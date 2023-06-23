using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.Base;
using UniquePlanners.Application.Dto.PlannerDto;

namespace UniquePlanners.Application.Dto.PlannerCoversDto
{
    public class PlannerCovers : BaseDto<int>
    {
        public int PlannerId { get; set; }
        public string Name { get; set; }
        public byte[]? Cover { get; set; }
        public virtual Planner? Planner { get; set; }
    }
}
