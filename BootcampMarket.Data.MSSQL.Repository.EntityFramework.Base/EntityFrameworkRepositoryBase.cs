using System.Collections.Generic;
using System.Threading.Tasks;
using BootcampMarket.Core.Data.Entity;
using BootcampMarket.Core.Data.Repository.Infrastructure;
using BootcampMarket.Data.MSSQL.Context.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BootcampMarket.Data.MSSQL.Repository.EntityFramework.Base
{
    public class EntityFrameworkRepositoryBase<TEntity, TId> :
        ISelectableAsyncRepository<TEntity, TId>,
        IInsertableAsyncRepository<TEntity>,
        IUpdatableAsyncRepository<TEntity>,
        IDeletableAsyncRepository<TEntity, TId>
        where TEntity : class, IEntity
        where TId : struct
    {
        public BootcampMarketDbContext Context { get; }

        public EntityFrameworkRepositoryBase(BootcampMarketDbContext context)
        {
            Context = context;
        }

        public Task<int> DeleteAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);

            return Task.FromResult(1);
        }

        public async Task<int> DeleteByIdAsync(TId id)
        {
            var entity = await GetByIdAsync(id);

            return await DeleteAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public Task<TEntity> GetByIdAsync(TId id)
        {
            return Context.Set<TEntity>().FindAsync(id).AsTask();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var inserted = await Context.Set<TEntity>().AddAsync(entity);

            return inserted.Entity;
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);

            return Task.FromResult(1);
        }
    }
}
