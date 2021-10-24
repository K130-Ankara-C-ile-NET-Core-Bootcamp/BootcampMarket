using System.Threading.Tasks;
using BootcampMarket.Core.Data.Entity;

namespace BootcampMarket.Core.Data.Repository.Infrastructure
{
    public interface IInsertableAsyncRepository<TEntity, TId>
        where TEntity : IEntity
        where TId : struct
    {
        Task<int> InsertAsync(TEntity entity);
    }
}
