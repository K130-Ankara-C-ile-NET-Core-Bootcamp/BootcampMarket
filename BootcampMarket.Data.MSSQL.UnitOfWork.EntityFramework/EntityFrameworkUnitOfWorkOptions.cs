using BootcampMarket.Core.Data.UnitOfWork.Infrastructure;

namespace BootcampMarket.Data.MSSQL.UnitOfWork.EntityFramework
{
    public class EntityFrameworkUnitOfWorkOptions : IUnitOfWorkOptions
    {
        public string ConnectionString { get; set; }

        public string MigrationAssembly { get; set; }
    }
}
