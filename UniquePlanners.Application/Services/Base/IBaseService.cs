using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePlanners.Application.Services.Base
{
    public interface IBaseService<T,TSearch>
    {
        Task<IEnumerable<T>> GetAll(TSearch search);
        Task<T> GetById(object id);
    }
}
