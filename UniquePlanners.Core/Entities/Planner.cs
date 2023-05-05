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

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<PlannerCovers> PlannerCovers { get; set; } = null!;
    }
}
