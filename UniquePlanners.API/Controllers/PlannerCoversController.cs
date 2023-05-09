using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniquePlanners.Application.Dto.PlannerCoversDto;
using UniquePlanners.Application.Services.PlannerCoversService;
using UniquePlanners.Application.Validators;

namespace UniquePlanners.API.Controllers
{
    public class PlannerCoversController : CRUDController<PlannerCovers,PlannerCoversSearchObject,PlannerCoversUpsertRequest,PlannerCoversUpsertRequest,PlannerCoversUpsertRequestValidator, PlannerCoversUpsertRequestValidator>
    {
        public PlannerCoversController(IPlannerCoversService service):base(service)
        {

        }
    }
}
