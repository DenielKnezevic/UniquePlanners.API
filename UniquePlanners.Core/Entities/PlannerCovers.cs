using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Core.Entities.Base;

namespace UniquePlanners.Core.Entities
{
    public class PlannerCovers : BaseEntity<int>
    {
        public int PlannerId { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Cover { get; set; } = null!;
        public virtual Planner Planner { get; set; } = null!;
    }
}
