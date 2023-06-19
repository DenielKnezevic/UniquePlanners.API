using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.UserDto;
using UniquePlanners.Application.Services.Base;
using UniquePlanners.Application.Services.UserService.Dto;

namespace UniquePlanners.Application.Services.UserService
{
    public interface IUserService : ICRUDService<User,UserSearchObject,UserInsertRequest,UserUpdateRequest>
    {
        Task<AuthenticatedResponse> Login(LoginDto loginDetails);
    }
}
