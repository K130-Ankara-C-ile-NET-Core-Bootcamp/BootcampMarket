using System.Data;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper.Base
{
    public class DapperRepositoryBase
    {
        public IDbConnection Connection { get; }

        public IDbTransaction Transaction { get; }

        public DapperRepositoryBase(
            IDbConnection connection,
            IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }
    }
}
