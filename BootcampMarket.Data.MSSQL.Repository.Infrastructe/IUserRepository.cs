using BootcampMarket.Core.Data.Repository.Infrastructure;
using BootcampMarket.Data.MSSQL.Entity;

namespace BootcampMarket.Data.MSSQL.Repository.Infrastructure
{
    public interface IUserRepository :
        ISelectableAsyncRepository<User, int>,
        IInsertableAsyncRepository<User, int>,
        IUpdatableAsyncRepository<User>,
        IDeletableAsyncRepository<User, int>
    {
    }
}
