using BootcampMarket.Core.Data.Repository.Infrastructure;
using BootcampMarket.Data.MSSQL.Entity;

namespace BootcampMarket.Data.MSSQL.Repository.Infrastructure
{
    public interface IProductRepository :
        ISelectableAsyncRepository<Product, int>,
        IInsertableAsyncRepository<Product, int>,
        IUpdatableAsyncRepository<Product>,
        IDeletableAsyncRepository<Product, int>
    {
    }
}
