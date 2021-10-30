using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;
using Dapper;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class CustomerDetailRepository : DapperRepositoryBase, ICustomerDetailRepository
    {
        public CustomerDetailRepository(
            IDbConnection connection,
            IDbTransaction transaction)
            : base(connection, transaction)
        {
        }

        public Task<int> DeleteAsync(CustomerDetail entity)
        {
            return DeleteByIdAsync(entity.CustomerId);
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            var sql = @"UPDATE CustomerDetail SET Status = 0
                        WHERE CustomerId = @CustomerId AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: new { CustomerId = id },
                transaction: Transaction);
        }

        public Task<IEnumerable<CustomerDetail>> GetAllAsync()
        {
            var sql = @"SELECT * FROM CustomerDetail WHERE Status = 1";

            return Connection.QueryAsync<CustomerDetail>(sql, transaction: Transaction);
        }

        public Task<CustomerDetail> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM CustomerDetail WHERE CustomerId = @Id AND Status = 1";

            return Connection.QueryFirstOrDefaultAsync<CustomerDetail>(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public async Task<CustomerDetail> InsertAsync(CustomerDetail entity)
        {
            var sql = @"INSERT INTO Country 
                        (CustomerId, Name, Surname, Birthdate, Status)
                        VALUES
                        (@CustomerId, @Name, @Surname, @Birthdate, @Status)";

            await Connection.QuerySingleAsync<int>(
                 sql,
                 param: entity,
                 transaction: Transaction);

            return entity;
        }

        public Task<int> UpdateAsync(CustomerDetail entity)
        {
            var sql = @"UPDATE Country SET
                        Name = @Name,
                        Surname = @Surname,
                        Birthdate = @Birthdate,
                        Status = @Status
                        WHERE CustomerId = @Id AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: entity,
                transaction: Transaction);
        }
    }
}
