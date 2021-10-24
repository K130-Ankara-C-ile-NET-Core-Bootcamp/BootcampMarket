using System;
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
            var sql = @"UPDATE District SET DeleteDate = GETDATE()
                        WHERE Id = @Id AND DeleteDate IS NULL";

            return Connection.ExecuteAsync(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<IEnumerable<District>> GetAllAsync()
        {
            var sql = @"SELECT * FROM District WHERE DeleteDate IS NULL";

            return Connection.QueryAsync<District>(sql, transaction: Transaction);
        }

        public Task<District> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM District WHERE ID = @Id AND DeleteDate IS NULL";

            return Connection.QueryFirstOrDefaultAsync<District>(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<int> InsertAsync(District entity)
        {
            var sql = @"INSERT INTO Country (CityId, Name, CreatedBy)
                        VALUES(@CityId, @Name, @CreatedBy)
                        SELECT SCOPE_IDENTITY()";

            return Connection.QuerySingleAsync<int>(
                sql,
                param: entity,
                transaction: Transaction);
        }

        public Task<int> UpdateAsync(District entity)
        {
            var sql = @"UPDATE Country District
                        CityId = @CityId,
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
