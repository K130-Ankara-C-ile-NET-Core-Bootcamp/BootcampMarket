using BootcampMarket.Data.MSSQL.Context.EntityFramework;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.EntityFramework.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.Repository.EntityFramework
{
    public class DistrictRepository :
        EntityFrameworkRepositoryBase<District, int>,
        IDistrictRepository
    {
        public DistrictRepository(BootcampMarketDbContext context) : base(context)
        {
        }
    }
}
