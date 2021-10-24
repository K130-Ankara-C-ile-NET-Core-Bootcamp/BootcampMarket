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
            var sql = @"UPDATE Product SET DeleteDate = GETDATE()
                        WHERE Id = @Id AND DeleteDate IS NULL";

            return Connection.ExecuteAsync(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            var sql = @"SELECT * FROM Product WHERE DeleteDate IS NULL";

            return Connection.QueryAsync<Product>(sql, transaction: Transaction);
        }

        public Task<Product> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM Product WHERE ID = @Id AND DeleteDate IS NULL";

            return Connection.QueryFirstOrDefaultAsync<Product>(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<int> InsertAsync(Product entity)
        {
            var sql = @"INSERT INTO Product 
                        (
                            Name, Price,
                            Discount, CreatedBy
                        )
                        VALUES
                        (
                            @Name, @Price,
                            @Discount, @CreatedBy
                        )
                        SELECT SCOPE_IDENTITY()";

            return Connection.QuerySingleAsync<int>(
                sql,
                param: entity,
                transaction: Transaction);
        }

        public Task<int> UpdateAsync(Product entity)
        {
            var sql = @"UPDATE Product SET
                        Name = @Name, 
                        Price = @Price,
                        Discount = @Discount,
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
