using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BootcampMarket.Data.MSSQL.Entity;
using BootcampMarket.Data.MSSQL.Repository.Infrastructure;
using Dapper;

namespace BootcampMarket.Data.MSSQL.Repository.Dapper
{
    public class CountryRepository : ICountryRepository
    {
        public Task<int> DeleteAsync(Country entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Country>> GetAllAsync()
        {
            var conStr = "Server=.;Database=BootcampMarketDb;Trusted_Connection=True;";

            var connection = new SqlConnection(conStr);

            var sql = @"SELECT * FROM Country WHERE DeleteDate IS NULL";

            return connection.QueryAsync<Country>(sql);
        }

        public Task<Country> GetByIdAsync(int id)
        {
            var conStr = "Server=.;Database=BootcampMarketDb;Trusted_Connection=True;";

            var connection = new SqlConnection(conStr);

            var sql = @"SELECT * FROM Country WHERE ID = @Id AND DeleteDate IS NULL";

            return connection.QueryFirstOrDefaultAsync<Country>(sql, new { Id = id });
        }

        public Task<int> InsertAsync(Country entity)
        {
            var conStr = "Server=.;Database=BootcampMarketDb;Trusted_Connection=True;";

            var sql = @"INSERT INTO Country (Name, CreatedBy)
                            VALUES(@Name, @CreatedBy)
                        SELECT SCOPE_IDENTITY()";

            var connection = new SqlConnection(conStr);

            return connection.QuerySingleAsync<int>(sql, entity);
        }

        public Task<int> UpdateAsync(Country entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
