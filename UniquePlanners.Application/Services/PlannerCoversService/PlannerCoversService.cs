using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.PlannerCoversDto;
using UniquePlanners.Application.Services.Base;
using UniquePlanners.Infrastructure.Persistance;

namespace UniquePlanners.Application.Services.PlannerCoversService
{
    public class PlannerCoversService : CRUDService<PlannerCovers, Core.Entities.PlannerCovers, PlannerCoversSearchObject, PlannerCoversUpsertRequest, PlannerCoversUpsertRequest>, IPlannerCoversService
    {
        public PlannerCoversService(ApplicationDbContext db, IMapper mapper):base(db,mapper)
        {

        }

        public override IQueryable<Core.Entities.PlannerCovers> AddInclude(IQueryable<Core.Entities.PlannerCovers> entity, PlannerCoversSearchObject search)
        {
            if(search.IncludePlanner.HasValue && search.IncludePlanner == true)
            {
                entity = entity.Include(x => x.Planner);
            }

            return entity;
        }
    }
}
