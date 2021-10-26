using System.Threading.Tasks;
using BootcampMarket.Core.Data.Entity;

namespace BootcampMarket.Core.Data.Repository.Infrastructure
{
    public interface IInsertableAsyncRepository<TEntity>
        where TEntity : IEntity
    {
        Task<TEntity> InsertAsync(TEntity entity);
    }
}
