using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniquePlanners.Application.Dto.PlannerDto;
using UniquePlanners.Application.Services.PlannerService;

namespace UniquePlanners.API.Controllers
{
    public class PlannerController : CRUDController<Planner,PlannerSearchObject,PlannerUpsertRequest,PlannerUpsertRequest>
    {
        public PlannerController(IPlannerService service):base(service)
        {

        }
    }
}
