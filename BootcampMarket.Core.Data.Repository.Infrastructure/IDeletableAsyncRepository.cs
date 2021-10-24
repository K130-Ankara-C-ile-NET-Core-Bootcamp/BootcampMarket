using System.Threading.Tasks;
using BootcampMarket.Core.Data.Entity;

namespace BootcampMarket.Core.Data.Repository.Infrastructure
{
    public interface IDeletableAsyncRepository<TEntity, TId>
        where TEntity : IEntity
        where TId : struct
    {
        Task<int> DeleteAsync(TEntity entity);

        Task<int> DeleteByIdAsync(TId id);
    }
}
