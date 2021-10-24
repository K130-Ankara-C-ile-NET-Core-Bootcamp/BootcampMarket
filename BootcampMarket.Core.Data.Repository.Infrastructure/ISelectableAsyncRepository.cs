using System.Collections.Generic;
using System.Threading.Tasks;
using BootcampMarket.Core.Data.Entity;

namespace BootcampMarket.Core.Data.Repository.Infrastructure
{
    public interface ISelectableAsyncRepository<TEntity, TId>
        where TEntity : IEntity
        where TId : struct
    {
        Task<TEntity> GetByIdAsync(TId id);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
