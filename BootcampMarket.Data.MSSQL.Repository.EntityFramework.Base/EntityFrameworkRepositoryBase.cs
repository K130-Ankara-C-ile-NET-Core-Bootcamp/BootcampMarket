using System.Collections.Generic;
using System.Linq;
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
            entity.Status = false;

            return UpdateAsync(entity);
        }

        public async Task<int> DeleteByIdAsync(TId id)
        {
            var entity = await GetByIdAsync(id);

            return await DeleteAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().Where(x => x.Status).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            var entity = await Context.Set<TEntity>().FindAsync(id);

            return entity?.Status == true ? entity : null;
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
