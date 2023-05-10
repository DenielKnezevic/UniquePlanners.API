using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePlanners.Application.Dto.PlannerCoversDto
{
    public class PlannerCoversUpsertRequest
    {
        public int PlannerId { get; set; }
        public byte[]? Cover { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
