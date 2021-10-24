using BootcampMarket.Core.Data.Repository.Infrastructure;
using BootcampMarket.Data.MSSQL.Entity;

namespace BootcampMarket.Data.MSSQL.Repository.Infrastructure
{
    public interface ICustomerRepository :
        ISelectableAsyncRepository<Customer, int>,
        IInsertableAsyncRepository<Customer, int>,
        IUpdatableAsyncRepository<Customer>,
        IDeletableAsyncRepository<Customer, int>
    {
    }
}
