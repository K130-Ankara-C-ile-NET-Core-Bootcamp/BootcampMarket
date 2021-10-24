using System.Threading.Tasks;
using BootcampMarket.Core.Data.Entity;

namespace BootcampMarket.Core.Data.Repository.Infrastructure
{
    public interface IUpdatableAsyncRepository<TEntity> 
        where TEntity : IEntity
    {
        Task<int> UpdateAsync(TEntity entity);
    }
}
