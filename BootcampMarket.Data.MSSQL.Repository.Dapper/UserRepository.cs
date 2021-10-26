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
    public class UserRepository : DapperRepositoryBase, IUserRepository
    {
        public UserRepository(
            IDbConnection connection,
            IDbTransaction transaction)
            : base(connection, transaction)
        {
        }

        public Task<int> DeleteAsync(User entity)
        {
            return DeleteByIdAsync(entity.Id);
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            var sql = @"UPDATE [User] SET DeleteDate = GETDATE()
                        WHERE Id = @Id AND DeleteDate IS NULL";

            return Connection.ExecuteAsync(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            var sql = @"SELECT * FROM [User] WHERE DeleteDate IS NULL";

            return Connection.QueryAsync<User>(sql, transaction: Transaction);
        }

        public Task<User> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM [User] WHERE ID = @Id AND DeleteDate IS NULL";

            return Connection.QueryFirstOrDefaultAsync<User>(
                sql,
                param: new { Id = id },
                transaction: Transaction);
        }

        public async Task<User> InsertAsync(User entity)
        {
            var sql = @"INSERT INTO [User] 
                        (Email, Password, UserName, CreatedById)
                        VALUES
                        (@Email, @Password, @UserName, @CreatedById)
                        SELECT SCOPE_IDENTITY()";

            var id = await Connection.QuerySingleAsync<int>(
                sql,
                param: entity,
                transaction: Transaction);

            entity.Id = id;

            return entity;
        }

        public Task<int> UpdateAsync(User entity)
        {
            var sql = @"UPDATE [User] SET
                        Email = @Email, 
                        Password = @Password, 
                        UserName = @UserName,
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
