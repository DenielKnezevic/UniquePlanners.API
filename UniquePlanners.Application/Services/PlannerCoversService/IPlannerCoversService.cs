using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.PlannerCoversDto;
using UniquePlanners.Application.Services.Base;

namespace UniquePlanners.Application.Services.PlannerCoversService
{
    public interface IPlannerCoversService : ICRUDService<PlannerCovers,PlannerCoversSearchObject,PlannerCoversUpsertRequest,PlannerCoversUpsertRequest>
    {
    }
}
