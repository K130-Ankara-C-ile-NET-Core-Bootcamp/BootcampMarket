using BootcampMarket.Data.MSSQL.Context.EntityFramework;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.EntityFramework.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;

namespace BootcampMarket.Data.MSSQL.Repository.EntityFramework
{
    public class CustomerAddressRepository :
        EntityFrameworkRepositoryBase<CustomerAddress, int>,
        ICustomerAddressRepository
    {
        public CustomerAddressRepository(BootcampMarketDbContext context) : base(context)
        {
        }
    }
}
