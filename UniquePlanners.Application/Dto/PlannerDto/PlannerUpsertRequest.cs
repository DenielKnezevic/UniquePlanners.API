using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePlanners.Application.Dto.PlannerDto
{
    public class PlannerUpsertRequest
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
    }
}
