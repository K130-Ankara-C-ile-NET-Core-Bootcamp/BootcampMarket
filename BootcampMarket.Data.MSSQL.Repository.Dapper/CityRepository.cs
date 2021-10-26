using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;
using Dapper;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class CityRepository : DapperRepositoryBase, ICityRepository
    {
        public CityRepository(
            IDbConnection connection, 
            IDbTransaction transaction) 
            : base(connection, transaction)
        {
        }

        public Task<int> DeleteAsync(City entity)
        {
            return DeleteByIdAsync(entity.Id);
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            var sql = @"UPDATE City SET DeleteDate = GETDATE()
                        WHERE Id = @Id AND DeleteDate IS NULL";

            return Connection.ExecuteAsync(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<IEnumerable<City>> GetAllAsync()
        {
            var sql = @"SELECT * FROM City WHERE DeleteDate IS NULL";

            return Connection.QueryAsync<City>(sql, transaction: Transaction);
        }

        public Task<City> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM City WHERE ID = @Id AND DeleteDate IS NULL";

            return Connection.QueryFirstOrDefaultAsync<City>(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public async Task<City> InsertAsync(City entity)
        {
            var sql = @"INSERT INTO City (CountryId, Name, CreatedById)
                            VALUES(@CountryId, @Name, @CreatedById)
                        SELECT SCOPE_IDENTITY()";

            var id = await Connection.QuerySingleAsync<int>(
                sql,
                param: entity,
                transaction: Transaction);

            entity.Id = id;

            return entity;
        }

        public Task<int> UpdateAsync(City entity)
        {
            var sql = @"UPDATE City SET
                        CountryId = @CountryId,
                        Name = @Name,
                        ModifyDate = GETDATE(),
                        ModifiedById = @ModifiedById
                        WHERE ID = @Id AND DELETETIME IS NULL";

            return Connection.ExecuteAsync(
                sql,
                param: entity,
                transaction: Transaction);
        }
    }
}
