using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;
using Dapper;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class CustomerRepository : DapperRepositoryBase, ICustomerRepository
    {
        public CustomerRepository(
            IDbConnection connection, 
            IDbTransaction transaction) 
            : base(connection, transaction)
        {
        }

        public Task<int> DeleteAsync(Customer entity)
        {
            return DeleteByIdAsync(entity.Id);
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            var sql = @"UPDATE Customer SET Status = 0
                        WHERE Id = @Id AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            var sql = @"SELECT * FROM Customer WHERE Status = 1";

            return Connection.QueryAsync<Customer>(sql, transaction: Transaction);
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM Customer WHERE ID = @Id AND Status = 1";

            return Connection.QueryFirstOrDefaultAsync<Customer>(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public async Task<Customer> InsertAsync(Customer entity)
        {
            var sql = @"INSERT INTO Customer (Email, Password, IsActive, Status)
                            VALUES(@Email, @Password, @IsActive, @Status)
                        SELECT SCOPE_IDENTITY()";

            var id = await Connection.QuerySingleAsync<int>(
                sql,
                param: entity,
                transaction: Transaction);

            entity.Id = id;

            return entity;
        }

        public Task<int> UpdateAsync(Customer entity)
        {
            var sql = @"UPDATE Customer SET
                        Name = @Name,
                        Password = @Password,
                        IsActive = @IsActive,
                        Status = @Status
                        WHERE ID = @Id AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: entity,
                transaction: Transaction);
        }
    }
}
