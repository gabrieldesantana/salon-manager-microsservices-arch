using Dapper;
using SalonManager.Business.Core.Entities;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.Infrastructure.Context;

namespace SalonManager.Business.Infrastructure.Repositories
{
    public class SalonServiceQueryRepository : ISalonServiceQueryRepository
    {
        private DbSession _dbSession;

        public SalonServiceQueryRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<List<SalonService>> GetAllAsync(Guid tenantId, int pageNumber, int pageSize)
        {
            try
            {
                string query = """
                    SELECT s.*
                    FROM "SalonServices" s
                    WHERE "IsActived" = true AND "TenantId" = @TenantId
                    ORDER BY s."Id"
                    LIMIT @PageSize OFFSET @PageSize * (@PageNumber - 1);
                    """;
                
                    var parameters = new { PageNumber = pageNumber, PageSize = pageSize, TenantId = tenantId };

                var records = await _dbSession.Connection.QueryAsync<SalonService>(
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

        public async Task<SalonService> GetByIdAsync(Guid id, Guid tenantId)
        {
            try
            {
                string query = """
                    SELECT s.*
                    FROM "SalonServices" s
                    WHERE s."IsActived" = true 
                    AND s."Id" = @Id
                    AND s."TenantId" = @TenantId
                    """;

                var parameters = new { Id = id, TenantId = tenantId };

                var record = await _dbSession.Connection.QueryFirstAsync<SalonService>(
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
