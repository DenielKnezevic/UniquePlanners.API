using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Infrastructure.Persistance;

namespace UniquePlanners.Application.Services.Base
{
    public class CRUDService<T, TDb, TSearch, TInsertRequest, TUpdateRequest> : BaseService<T, TDb, TSearch>, ICRUDService<T, TSearch, TInsertRequest, TUpdateRequest>
        where T : class where TDb : class where TSearch : class where TInsertRequest : class where TUpdateRequest : class
    {
        public CRUDService(ApplicationDbContext db, IMapper mapper):base(db, mapper)
        {

        }

        public virtual async Task<T> Insert(TInsertRequest request)
        {
            var set = _db.Set<TDb>();

            TDb entity = _mapper.Map<TDb>(request);

            await set.AddAsync(entity);

            await BeforeInsert(request,entity);

            await _db.SaveChangesAsync();

            return _mapper.Map<T>(entity);
        }

        public virtual async Task<T> Update(TUpdateRequest request, object id)
        {
            var entity = await _db.Set<TDb>().FindAsync(id);

            _mapper.Map(request,entity);

            await _db.SaveChangesAsync();

            return _mapper.Map<T>(entity);
        }

        public virtual async Task<T> Delete(object id)
        {
            var entity = await _db.Set<TDb>().FindAsync(id);

            var tmp = entity;

            if(entity != null)
                _db.Remove(entity);

            await _db.SaveChangesAsync();

            return _mapper.Map<T>(tmp);
        }

        public virtual async Task BeforeInsert(TInsertRequest insert, TDb entity)
        {

        }
    }
}
