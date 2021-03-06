using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Dapper.Base;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;
using Dapper;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class ProductCommentRepository : DapperRepositoryBase, IProductCommentRepository
    {
        public ProductCommentRepository(
            IDbConnection connection, 
            IDbTransaction transaction) 
            : base(connection, transaction)
        {
        }

        public Task<int> DeleteAsync(ProductComment entity)
        {
            return DeleteByIdAsync(entity.Id);
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            var sql = @"UPDATE ProductComment SET Status = 0
                        WHERE Id = @Id AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<IEnumerable<ProductComment>> GetAllAsync()
        {
            var sql = @"SELECT * FROM ProductComment WHERE Status = 1";

            return Connection.QueryAsync<ProductComment>(sql, transaction: Transaction);
        }

        public Task<ProductComment> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM ProductComment WHERE ID = @Id AND Status = 1";

            return Connection.QueryFirstOrDefaultAsync<ProductComment>(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public async Task<ProductComment> InsertAsync(ProductComment entity)
        {
            var sql = @"INSERT INTO ProductComment 
                        (CustomerId, ProductId, Comment, Status)
                        VALUES
                        (@CustomerId, @ProductId, @Comment, @Status)
                        SELECT SCOPE_IDENTITY()";

            var id = await Connection.QuerySingleAsync<int>(
                sql,
                param: entity,
                transaction: Transaction);

            entity.Id = id;

            return entity;
        }

        public Task<int> UpdateAsync(ProductComment entity)
        {
            var sql = @"UPDATE ProductComment SET
                        CustomerId = @CustomerId, 
                        ProductId = @ProductId, 
                        Comment = @Comment,
                        Status = @Status
                        WHERE ID = @Id AND Status = 1";

            return Connection.ExecuteAsync(
                sql,
                param: entity,
                transaction: Transaction);
        }
    }
}
