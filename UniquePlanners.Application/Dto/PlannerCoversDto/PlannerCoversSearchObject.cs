using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.Base;

namespace UniquePlanners.Application.Dto.PlannerCoversDto
{
    public class PlannerCoversSearchObject : BaseSearchObject
    {
        public bool? IncludePlanner { get; set; }
    }
}
