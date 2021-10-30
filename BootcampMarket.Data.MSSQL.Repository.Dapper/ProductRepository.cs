using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;
using Dapper;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class ProductRepository : DapperRepositoryBase, IProductRepository
    {
        public ProductRepository(
            IDbConnection connection, 
            IDbTransaction transaction) 
            : base(connection, transaction)
        {
        }

        public Task<int> DeleteAsync(Product entity)
        {
            return DeleteByIdAsync(entity.Id);
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            var sql = @"UPDATE Product SET Status = 0
                        WHERE Id = @Id AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            var sql = @"SELECT * FROM Product WHERE Status = 1";

            return Connection.QueryAsync<Product>(sql, transaction: Transaction);
        }

        public Task<Product> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM Product WHERE ID = @Id AND Status = 1";

            return Connection.QueryFirstOrDefaultAsync<Product>(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public async Task<Product> InsertAsync(Product entity)
        {
            var sql = @"INSERT INTO Product 
                        (
                            Name, Price, Discount, Status
                        )
                        VALUES
                        (
                            @Name, @Price, @Discount, @Status
                        )
                        SELECT SCOPE_IDENTITY()";

            var id = await Connection.QuerySingleAsync<int>(
                sql,
                param: entity,
                transaction: Transaction);

            entity.Id = id;

            return entity;
        }

        public Task<int> UpdateAsync(Product entity)
        {
            var sql = @"UPDATE Product SET
                        Name = @Name, 
                        Price = @Price,
                        Discount = @Discount,
                        Status = @Status
                        WHERE ID = @Id AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: entity,
                transaction: Transaction);
        }
    }
}
