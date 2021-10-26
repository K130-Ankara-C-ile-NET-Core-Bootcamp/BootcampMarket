using BootcampMarket.Data.MSSQL.Context.EntityFramework;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.EntityFramework.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.Repository.EntityFramework
{
    public class CustomerDetailRepository :
        EntityFrameworkRepositoryBase<CustomerDetail, int>,
        ICustomerDetailRepository
    {
        public CustomerDetailRepository(BootcampMarketDbContext context) : base(context)
        {
        }
    }
}
