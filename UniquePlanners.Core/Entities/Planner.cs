using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Core.Entities.Base;

namespace UniquePlanners.Core.Entities
{
    public class Planner : BaseEntity<int>
    {
        public Planner()
        {
            PlannerCovers = new HashSet<PlannerCovers>();
        }

        public string? Name { get; set; }
        public ICollection<PlannerCovers> PlannerCovers { get; set; }
    }
}
