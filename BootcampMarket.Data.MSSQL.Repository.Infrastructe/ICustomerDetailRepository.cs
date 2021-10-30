using BootcampMarket.Core.Data.Repository.Infrastructure;
using BootcampMarket.Data.MSSQL.Entity;

namespace BootcampMarket.Data.MSSQL.Repository.Infrastructure
{
    public interface ICustomerDetailRepository :
        ISelectableAsyncRepository<CustomerDetail, int>,
        IInsertableAsyncRepository<CustomerDetail>,
        IUpdatableAsyncRepository<CustomerDetail>,
        IDeletableAsyncRepository<CustomerDetail, int>
    {
    }
}
