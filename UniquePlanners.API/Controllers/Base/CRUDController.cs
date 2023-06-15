using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniquePlanners.Application.Dto.Base;
using UniquePlanners.Application.Services.Base;

namespace UniquePlanners.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController<T,TSearch,TInsertRequest,TUpdateRequest,TValidatorInsert,TValidatorUpdate> : BaseController<T,TSearch>
        where T : class
        where TSearch : BaseSearchObject
        where TInsertRequest : class 
        where TUpdateRequest : class 
        where TValidatorInsert : AbstractValidator<TInsertRequest>, new()
        where TValidatorUpdate : AbstractValidator<TUpdateRequest>, new()
    {
        public CRUDController(ICRUDService<T,TSearch,TInsertRequest,TUpdateRequest> service):base(service)
        {

        }

        [Authorize]
        [HttpPost]
        public virtual async Task<ActionResult<T>> Post([FromBody]TInsertRequest entity)
        {
            var validator = new TValidatorInsert().Validate(entity);
            if(!validator.IsValid)
                return BadRequest(validator.Errors);
            return Ok(await ((ICRUDService<T, TSearch, TInsertRequest, TUpdateRequest>)_service).Insert(entity));
        }

        [Authorize]
        [HttpPut("{id}")]
        public virtual async Task<ActionResult<T>> Put([FromBody]TUpdateRequest entity, int id)
        {
            var validator = new TValidatorUpdate().Validate(entity);
            if (!validator.IsValid)
                return BadRequest(validator.Errors);
            return Ok(await ((ICRUDService<T, TSearch, TInsertRequest, TUpdateRequest>)_service).Update(entity, id));
        }
    }
}
