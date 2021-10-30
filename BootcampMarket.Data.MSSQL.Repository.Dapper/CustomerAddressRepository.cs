using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;
using Dapper;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class CustomerAddressRepository : DapperRepositoryBase, ICustomerAddressRepository
    {
        public CustomerAddressRepository(
            IDbConnection connection,
            IDbTransaction transaction)
            : base(connection, transaction)
        {
        }

        public Task<int> DeleteAsync(CustomerAddress entity)
        {
            return DeleteByIdAsync(entity.Id);
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            var sql = @"UPDATE CustomerAddress SET Status = 0
                        WHERE Id = @Id AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<IEnumerable<CustomerAddress>> GetAllAsync()
        {
            var sql = @"SELECT * FROM CustomerAddress WHERE Status = 1";

            return Connection.QueryAsync<CustomerAddress>(sql, transaction: Transaction);
        }

        public Task<CustomerAddress> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM CustomerAddress WHERE ID = @Id AND Status = 1";

            return Connection.QueryFirstOrDefaultAsync<CustomerAddress>(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public async Task<CustomerAddress> InsertAsync(CustomerAddress entity)
        {
            var sql = @"INSERT INTO Country 
                        (
                         CustomerId, CountryId, CityId, 
                         DistrictId, Address, Status
                        )
                        VALUES
                        (
                        @CustomerId, @CountryId, @CityId, 
                        @DistrictId, @Address, @Status
                        )
                        SELECT SCOPE_IDENTITY()";

            var id = await Connection.QuerySingleAsync<int>(
                sql,
                param: entity,
                transaction: Transaction);

            entity.Id = id;

            return entity;
        }

        public Task<int> UpdateAsync(CustomerAddress entity)
        {
            var sql = @"UPDATE Country SET
                        CustomerId = @CustomerId,
                        CountryId = @CountryId,
                        CityId = @CityId,
                        DistrictId = @DistrictId,
                        Address = @Address,
                        Status = @Status
                        WHERE ID = @Id AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: entity,
                transaction: Transaction);
        }
    }
}
