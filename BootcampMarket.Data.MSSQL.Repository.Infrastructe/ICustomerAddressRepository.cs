using BootcampMarket.Core.Data.Repository.Infrastructure;
using BootcampMarket.Data.MSSQL.Entity;

namespace BootcampMarket.Data.MSSQL.Repository.Infrastructure
{
    public interface ICustomerAddressRepository :
        ISelectableAsyncRepository<CustomerAddress, int>,
        IInsertableAsyncRepository<CustomerAddress, int>,
        IUpdatableAsyncRepository<CustomerAddress>,
        IDeletableAsyncRepository<CustomerAddress, int>
    {
    }
}
