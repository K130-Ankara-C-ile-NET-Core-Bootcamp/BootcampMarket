using System.Collections.Generic;
using System.Threading.Tasks;
using BootcampMarket.Core.Data.Repository.Infrastructure;
using BootcampMarket.Data.MSSQL.Entity;

namespace BootcampMarket.Data.MSSQL.Repository.Infrastructure
{
    public interface ICountryRepository :
        ISelectableAsyncRepository<Country, int>,
        IInsertableAsyncRepository<Country, int>,
        IUpdatableAsyncRepository<Country>,
        IDeletableAsyncRepository<Country, int>
    {
    }
}
