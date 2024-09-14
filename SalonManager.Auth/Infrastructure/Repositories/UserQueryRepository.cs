using Dapper;
using SalonManager.Auth.Core.Entities;
using SalonManager.Auth.Core.Interfaces.Repositories;
using SalonManager.Auth.Infrastructure.Context;

namespace SalonManager.Auth.Infrastructure.Repositories
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private DbSession _dbSession;

        public UserQueryRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<List<User>> GetAllAsync(int pageNumber, int pageSize)
        {
            try
            {
                string query = """
                    SELECT u.*
                    FROM "Users" u
                    WHERE u."IsActived" = true
                    ORDER BY u."Id"
                    LIMIT @PageSize OFFSET @PageSize * (@PageNumber - 1);
                    """;

                var parameters = new { PageNumber = pageNumber, PageSize = pageSize };

                var records = await _dbSession.Connection.QueryAsync<User>(
                    query,
                    parameters,
                    transaction: _dbSession.Transaction);

                return records.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            try
            {
                string query = """
                    SELECT u.*
                    FROM "Users" u
                    WHERE u."IsActived" = true 
                    AND u."Id" = @Id
                    """;

                var parameters = new { Id = id };

                var record = await _dbSession.Connection.QueryFirstAsync<User>(
                    query,
                    parameters,
                    transaction: _dbSession.Transaction);

                return record;
            }
            catch
            {
                return null;
            }
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            try
            {
                string query = """
                    SELECT u.*
                    FROM "Users" u
                    WHERE u."IsActived" = true
                    AND u."Email" = @Email
                    AND u."Password" = @Password
                    """;

                var parameters = new { Email = email, Password = password };

                var record = await _dbSession.Connection.QueryFirstAsync<User>(
                    query,
                    parameters,
                    transaction: _dbSession.Transaction);

                return record;
            }
            catch
            {
                return null;
            }
        }

        public async Task<User> GetUserByIdAndPasswordAsync(Guid id, string password)
        {
            try
            {
                string query = """
                    SELECT u.*
                    FROM "Users" u
                    WHERE u."IsActived" = true 
                    AND u."Id" = @Id
                    AND u."Password" = @Password
                    """;

                var parameters = new { Id = id, Password = password};

                var record = await _dbSession.Connection.QueryFirstAsync<User>(
                    query,
                    parameters,
                    transaction: _dbSession.Transaction);

                return record;
            }
            catch
            {
                return null;
            }
        }
    }
}
