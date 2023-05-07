using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniquePlanners.Application.Services.Base;

namespace UniquePlanners.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T,TSearch> : ControllerBase where T : class where TSearch : class 
    {
        public readonly IBaseService<T,TSearch> _service;
        public BaseController(IBaseService<T, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> GetAll([FromQuery]TSearch search)
        {
            return Ok(await _service.GetAll(search));
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
    }
}
