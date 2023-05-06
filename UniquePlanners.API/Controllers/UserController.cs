using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniquePlanners.Application.Dto.UserDto;
using UniquePlanners.Application.Services.UserService;
using UniquePlanners.Application.Services.UserService.Dto;

namespace UniquePlanners.API.Controllers
{
    public class UserController : CRUDController<User,UserSearchObject,UserInsertRequest,UserUpdateRequest>
    {
        public UserController(IUserService service):base(service)
        {

        }
    }
}
