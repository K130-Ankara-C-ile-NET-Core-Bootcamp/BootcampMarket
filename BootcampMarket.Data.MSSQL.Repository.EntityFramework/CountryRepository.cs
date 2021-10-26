using BootcampMarket.Data.MSSQL.Context.EntityFramework;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.EntityFramework.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.Repository.EntityFramework
{
    public class CountryRepository :
        EntityFrameworkRepositoryBase<Country, int>,
        ICountryRepository
    {
        public CountryRepository(BootcampMarketDbContext context) : base(context)
        {
        }
    }
}
