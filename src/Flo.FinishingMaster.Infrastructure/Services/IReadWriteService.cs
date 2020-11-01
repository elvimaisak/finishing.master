using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flo.FinishingMaster.Infrastructure.Services
{
    public interface IReadWriteService<T> where T : class
    {
        Task<T> FindByIdAsync(Guid id);
        Task<T> UpdateAsync(T entity);
        void Delete(IEnumerable<Guid> ids);
    }
}
