using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniquePlanners.Application.Services.Base;

namespace UniquePlanners.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController<T,TSearch,TInsertRequest,TUpdateRequest> : BaseController<T,TSearch>
        where T : class where TSearch : class where TInsertRequest : class where TUpdateRequest : class
    {
        public CRUDController(ICRUDService<T,TSearch,TInsertRequest,TUpdateRequest> service):base(service)
        {

        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> Post([FromBody]TInsertRequest entity)
        {
            return Ok(await ((ICRUDService<T, TSearch, TInsertRequest, TUpdateRequest>)_service).Insert(entity));
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<T>> Put([FromBody]TUpdateRequest entity, object id)
        {
            return Ok(await ((ICRUDService<T, TSearch, TInsertRequest, TUpdateRequest>)_service).Update(entity, id));
        }
    }
}
