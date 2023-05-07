using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniquePlanners.Application.Dto.PlannerCoversDto;
using UniquePlanners.Application.Services.PlannerCoversService;

namespace UniquePlanners.API.Controllers
{
    public class PlannerCoversController : CRUDController<PlannerCovers,PlannerCoversSearchObject,PlannerCoversUpsertRequest,PlannerCoversUpsertRequest>
    {
        public PlannerCoversController(IPlannerCoversService service):base(service)
        {

        }
    }
}
