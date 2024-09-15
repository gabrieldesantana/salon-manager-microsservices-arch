using Dapper;
using SalonManager.Customers.Core.Entities;
using SalonManager.Customers.Core.Interfaces.Repositories;
using SalonManager.Customers.Infrastructure.Context;

namespace SalonManager.Customers.Infrastructure.Repositories
{
    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        private DbSession _dbSession;

        public CustomerQueryRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<List<Customer>> GetAllAsync(Guid tenantId, int pageNumber, int pageSize)
        {
            try
            {
                string query = """
                    SELECT c.*
                    FROM "Customers" c
                    WHERE "IsActived" = True AND "TenantId" = @TenantId
                    ORDER BY c."Id"
                    LIMIT @PageSize OFFSET @PageSize * (@PageNumber - 1);
                    """;

                var parameters = new { PageNumber = pageNumber, PageSize = pageSize, TenantId = tenantId };

                var records = await _dbSession.Connection.QueryAsync<Customer>(
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

        public async Task<Customer> GetByIdAsync(Guid id, Guid tenantId)
        {
            try
            {
                string query = """
                    SELECT c.*
                    FROM "Customers" c
                    WHERE c."IsActived" = True 
                    AND c."Id" = @Id
                    AND c."TenantId" = @TenantId
                    """;

                var parameters = new { Id = id, TenantId = tenantId };

                var record = await _dbSession.Connection.QueryFirstAsync<Customer>(
                    query,
                    parameters,
                    transaction: _dbSession.Transaction);

                return record;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
