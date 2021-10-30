using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;
using Dapper;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class DistrictRepository : DapperRepositoryBase, IDistrictRepository
    {
        public DistrictRepository(
            IDbConnection connection, 
            IDbTransaction transaction) 
            : base(connection, transaction)
        {
        }

        public Task<int> DeleteAsync(District entity)
        {
            return DeleteByIdAsync(entity.Id);
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            var sql = @"UPDATE District SET Status = 0
                        WHERE Id = @Id AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<IEnumerable<District>> GetAllAsync()
        {
            var sql = @"SELECT * FROM District WHERE Status = 1";

            return Connection.QueryAsync<District>(sql, transaction: Transaction);
        }

        public Task<District> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM District WHERE ID = @Id AND Status = 1";

            return Connection.QueryFirstOrDefaultAsync<District>(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public async Task<District> InsertAsync(District entity)
        {
            var sql = @"INSERT INTO Country (CityId, Name, Status)
                        VALUES(@CityId, @Name, @Status)
                        SELECT SCOPE_IDENTITY()";

            var id = await Connection.QuerySingleAsync<int>(
                sql,
                param: entity,
                transaction: Transaction);

            entity.Id = id;

            return entity;
        }

        public Task<int> UpdateAsync(District entity)
        {
            var sql = @"UPDATE Country District
                        CityId = @CityId,
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
