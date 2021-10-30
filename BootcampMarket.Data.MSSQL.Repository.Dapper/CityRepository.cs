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
            var sql = @"UPDATE City SET Status = 0
                        WHERE Id = @Id AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<IEnumerable<City>> GetAllAsync()
        {
            var sql = @"SELECT * FROM City WHERE Status = 1";

            return Connection.QueryAsync<City>(sql, transaction: Transaction);
        }

        public Task<City> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM City WHERE ID = @Id AND Status = 1";

            return Connection.QueryFirstOrDefaultAsync<City>(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public async Task<City> InsertAsync(City entity)
        {
            var sql = @"INSERT INTO City (CountryId, Name, Status)
                            VALUES(@CountryId, @Name, @Status)
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
                        Status = @Status
                        WHERE ID = @Id AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: entity,
                transaction: Transaction);
        }
    }
}
