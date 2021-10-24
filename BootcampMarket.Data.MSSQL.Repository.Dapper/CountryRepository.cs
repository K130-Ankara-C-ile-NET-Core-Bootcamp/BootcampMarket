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
            var sql = @"UPDATE Country SET DeleteDate = GETDATE()
                        WHERE Id = @Id AND DeleteDate IS NULL";

            return Connection.ExecuteAsync(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<IEnumerable<Country>> GetAllAsync()
        {
            var sql = @"SELECT * FROM Country WHERE DeleteDate IS NULL";

            return Connection.QueryAsync<Country>(sql, transaction: Transaction);
        }

        public Task<Country> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM Country WHERE ID = @Id AND DeleteDate IS NULL";

            return Connection.QueryFirstOrDefaultAsync<Country>(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<int> InsertAsync(Country entity)
        {
            var sql = @"INSERT INTO Country (Name, CreatedBy)
                            VALUES(@Name, @CreatedBy)
                        SELECT SCOPE_IDENTITY()";

            return Connection.QuerySingleAsync<int>(
                sql,
                param: entity,
                transaction: Transaction);
        }

        public Task<int> UpdateAsync(Country entity)
        {
            var sql = @"UPDATE Country SET
                        Name = @Name,
                        ModifyDate = GETDATE(),
                        ModifiedBy = @ModifiedBy
                        WHERE ID = @Id AND DELETETIME IS NULL";

            return Connection.ExecuteAsync(
                sql,
                param: entity,
                transaction: Transaction);
        }
    }
}
