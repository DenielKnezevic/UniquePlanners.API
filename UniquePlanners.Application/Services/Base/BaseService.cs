using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Infrastructure.Persistance;

namespace UniquePlanners.Application.Services.Base
{
    public class BaseService<T, TDb, TSearch> : IBaseService<T, TSearch> where T : class where TDb : class where TSearch : class
    {
        public readonly ApplicationDbContext _db;
        public readonly IMapper _mapper;

        public BaseService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<T>> GetAll(TSearch search = null)
        {
            var entity = _db.Set<TDb>().AsQueryable();

            entity = AddInclude(entity, search);

            entity =  AddFilter(entity, search);

            var result = _mapper.Map<IEnumerable<T>>(entity);

            return await Task.FromResult(result);

        }

        public virtual async Task<T> GetById(object id)
        {
            var entity = await _db.Set<TDb>().FindAsync(id);

            return _mapper.Map<T>(entity);
        }

        public virtual IQueryable<TDb> AddInclude(IQueryable<TDb> entity, TSearch search)
        {
            return entity;
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> entity, TSearch search)
        {
            return entity;
        }
    }
}
