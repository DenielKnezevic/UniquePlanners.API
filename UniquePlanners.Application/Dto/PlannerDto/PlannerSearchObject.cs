using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.Base;

namespace UniquePlanners.Application.Dto.PlannerDto
{
    public class PlannerSearchObject : BaseSearchObject
    {
        public string? Name { get; set; }
        public bool? IncludeUser { get; set; }
        public bool? IncludePlannerCovers { get; set; }
    }
}
