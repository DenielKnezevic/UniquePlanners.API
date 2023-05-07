using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.PlannerDto;
using UniquePlanners.Application.Services.Base;
using UniquePlanners.Infrastructure.Persistance;

namespace UniquePlanners.Application.Services.PlannerService
{
    public class PlannerService : CRUDService<Planner, Core.Entities.Planner, PlannerSearchObject, PlannerUpsertRequest, PlannerUpsertRequest>, IPlannerService
    {
        public PlannerService(ApplicationDbContext db, IMapper mapper):base(db, mapper)
        {

        }

        public override IQueryable<Core.Entities.Planner> AddInclude(IQueryable<Core.Entities.Planner> entity, PlannerSearchObject search)
        {
            if(search.IncludePlannerCovers.HasValue && search.IncludePlannerCovers == true)
            {
                entity = entity.Include(x => x.PlannerCovers);
            }

            if(search.IncludeUser.HasValue && search.IncludeUser == true)
            {
                entity = entity.Include(x => x.User);
            }

            return entity;
        }

        public override IQueryable<Core.Entities.Planner> AddFilter(IQueryable<Core.Entities.Planner> entity, PlannerSearchObject search)
        {
            if(string.IsNullOrWhiteSpace(search.Name) == false)
            {
                entity = entity.Where(x => x.Name.ToLower().StartsWith(search.Name.ToLower()));
            }

            return entity;
        }
    }
}
