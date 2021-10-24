using BootcampMarket.Core.Data.UnitOfWork.Infrastructure;

namespace BootcampMarket.Data.MSSQL.UnitOfWork.Dapper
{
    public class DapperUnitOfWorkOptions : IUnitOfWorkOptions
    {
        public string ConnectionString { get; set; }
    }
}
