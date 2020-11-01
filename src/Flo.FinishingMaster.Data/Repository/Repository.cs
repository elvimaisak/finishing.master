using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flo.FinishingMaster.Infrastructure.Entity;
using Flo.FinishingMaster.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Flo.FinishingMaster.Data
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext dataContext;

        protected Repository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dataContext.Set<T>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<T> AddOrUpdateAsync(T entity)
        {
            var result = await GetByIdAsync(entity.Id);

            if (result != null)
            {
                CopyFields(entity, result);
            }
            else
            {
                result = (await dataContext.Set<T>().AddAsync(entity)).Entity;
            }

            return result;
        }

        public void Delete(IEnumerable<Guid> ids)
        {
            var entities = dataContext.Set<T>().Where(c => ids.Contains(c.Id));

            dataContext.RemoveRange(entities);
        }

        public async Task SaveChangesAsync()
        {
            await dataContext.SaveChangesAsync();
        }

        protected abstract void CopyFields(T source, T target);

    }
}
