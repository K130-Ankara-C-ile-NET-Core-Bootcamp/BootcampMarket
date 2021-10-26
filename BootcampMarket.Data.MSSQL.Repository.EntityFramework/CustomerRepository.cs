using BootcampMarket.Data.MSSQL.Context.EntityFramework;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.EntityFramework.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.Repository.EntityFramework
{
    public class CustomerRepository :
        EntityFrameworkRepositoryBase<Customer, int>,
        ICustomerRepository
    {
        public CustomerRepository(BootcampMarketDbContext context) : base(context)
        {
        }
    }
}
