using BootcampMarket.Core.Data.Repository.Infrastructure;
using BootcampMarket.Data.MSSQL.Entity;

namespace BootcampMarket.Data.MSSQL.Repository.Infrastructure
{
    public interface ICityRepository :
        ISelectableAsyncRepository<City, int>,
        IInsertableAsyncRepository<City, int>,
        IUpdatableAsyncRepository<City>,
        IDeletableAsyncRepository<City, int>
    {
    }
}
