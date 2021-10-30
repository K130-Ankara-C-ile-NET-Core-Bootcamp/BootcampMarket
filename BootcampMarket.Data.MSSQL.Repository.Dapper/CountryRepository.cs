using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;
using Dapper;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class CountryRepository : DapperRepositoryBase, ICountryRepository
    {
        public CountryRepository(
            IDbConnection connection,
            IDbTransaction transaction)
            : base(connection, transaction)
        {
        }

        public Task<int> DeleteAsync(Country entity)
        {
            return DeleteByIdAsync(entity.Id);
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            var sql = @"UPDATE Country SET Status = 0
                        WHERE Id = @Id AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<IEnumerable<Country>> GetAllAsync()
        {
            var sql = @"SELECT * FROM Country WHERE Status = 1";

            return Connection.QueryAsync<Country>(sql, transaction: Transaction);
        }

        public Task<Country> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM Country WHERE ID = @Id AND Status = 1";

            return Connection.QueryFirstOrDefaultAsync<Country>(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public async Task<Country> InsertAsync(Country entity)
        {
            var sql = @"INSERT INTO Country (Name, Status)
                            VALUES(@Name, @Status)
                        SELECT SCOPE_IDENTITY()";

            var id = await Connection.QuerySingleAsync<int>(
                sql,
                param: entity,
                transaction: Transaction);

            entity.Id = id;

            return entity;
        }

        public Task<int> UpdateAsync(Country entity)
        {
            var sql = @"UPDATE Country SET
                        Name = @Name,
                        Status = @Status
                        WHERE ID = @Id AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: entity,
                transaction: Transaction);
        }
    }
}
