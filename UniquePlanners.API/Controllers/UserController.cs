using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody]LoginDto loginDetails)
        {
            return await ((IUserService)_service).Login(loginDetails);
        }
        [AllowAnonymous]
        public override Task<ActionResult<User>> Post([FromBody] UserInsertRequest entity)
        {
            return base.Post(entity);
        }
    }
}
