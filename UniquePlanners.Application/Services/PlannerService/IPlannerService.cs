using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.PlannerDto;
using UniquePlanners.Application.Services.Base;

namespace UniquePlanners.Application.Services.PlannerService
{
    public interface IPlannerService : ICRUDService<Planner,PlannerSearchObject,PlannerUpsertRequest,PlannerUpsertRequest>
    {
    }
}
