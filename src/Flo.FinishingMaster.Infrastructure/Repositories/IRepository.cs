using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flo.FinishingMaster.Infrastructure.Entity;

namespace Flo.FinishingMaster.Infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddOrUpdateAsync(T entity);
        void Delete(IEnumerable<Guid> ids);
        Task SaveChangesAsync();
    }
}
