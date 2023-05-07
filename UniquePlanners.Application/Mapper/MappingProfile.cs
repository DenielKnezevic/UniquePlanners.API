using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.PlannerCoversDto;
using UniquePlanners.Application.Dto.PlannerDto;
using UniquePlanners.Application.Dto.UserDto;
using UniquePlanners.Application.Services.UserService.Dto;

namespace UniquePlanners.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, Core.Entities.User>().ReverseMap();
            CreateMap<UserInsertRequest, Core.Entities.User>().ReverseMap();
            CreateMap<UserUpdateRequest, Core.Entities.User>().ReverseMap();
            CreateMap<Planner, Core.Entities.Planner>().ReverseMap();
            CreateMap<PlannerUpsertRequest, Core.Entities.Planner>().ReverseMap();
            CreateMap<PlannerUpsertRequest, Core.Entities.Planner>().ReverseMap();
            CreateMap<PlannerCovers, Core.Entities.PlannerCovers>().ReverseMap();
            CreateMap<PlannerCoversUpsertRequest, Core.Entities.PlannerCovers>().ReverseMap();
            CreateMap<PlannerCoversUpsertRequest, Core.Entities.PlannerCovers>().ReverseMap();
        }
    }
}
