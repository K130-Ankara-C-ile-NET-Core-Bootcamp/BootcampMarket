using BootcampMarket.Core.Data.Repository.Infrastructure;
using BootcampMarket.Data.MSSQL.Entity;

namespace BootcampMarket.Data.MSSQL.Repository.Infrastructure
{
    public interface IProductCommentRepository :
        ISelectableAsyncRepository<ProductComment, int>,
        IInsertableAsyncRepository<ProductComment, int>,
        IDeletableAsyncRepository<ProductComment, int>
    {
    }
}
