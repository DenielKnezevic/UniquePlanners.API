using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePlanners.Application.Services.Base
{
    public interface ICRUDService<T,TSearch,TUpdateRequest,TInsertRequest> : IBaseService<T,TSearch>
    {
        Task<T> Insert(TInsertRequest request);
        Task<T> Update(TUpdateRequest request, object id);
        Task<T> Delete(object id);
    }
}
