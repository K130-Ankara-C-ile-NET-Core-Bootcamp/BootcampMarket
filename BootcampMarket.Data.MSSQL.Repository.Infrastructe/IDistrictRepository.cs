using BootcampMarket.Core.Data.Repository.Infrastructure;
using BootcampMarket.Data.MSSQL.Entity;

namespace BootcampMarket.Data.MSSQL.Repository.Infrastructure
{
    public interface IDistrictRepository :
        ISelectableAsyncRepository<District, int>,
        IInsertableAsyncRepository<District>,
        IUpdatableAsyncRepository<District>,
        IDeletableAsyncRepository<District, int>
    {
    }
}
