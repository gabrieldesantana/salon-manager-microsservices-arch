using Dapper;
using SalonManager.Business.Core.Entities;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.Infrastructure.Context;

namespace SalonManager.Business.Infrastructure.Repositories
{
    public class CompanyQueryRepository : ICompanyQueryRepository
    {
        private DbSession _dbSession;

        public CompanyQueryRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<List<Company>> GetAllAsync(int pageNumber, int pageSize)
        {
            try
            {
                string query = """
                    SELECT c.*
                    FROM "Companies" c
                    WHERE "IsActived" = true
                    ORDER BY c."Id"
                    LIMIT @PageSize OFFSET @PageSize * (@PageNumber - 1);
                    """;

                var parameters = new { PageNumber = pageNumber, PageSize = pageSize};

                var records = await _dbSession.Connection.QueryAsync<Company>(
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

        public async Task<Company> GetByIdAsync(Guid id, Guid tenantId)
        {
            try
            {
                string query = """
                    SELECT c.*, e.*
                    FROM "Companies" c
                    INNER JOIN "Employees" e ON c."Id" = e."CompanyId"
                    AND c."TenantId" = e."TenantId" AND e."IsActived" = true
                    WHERE c."IsActived" = true
                    AND c."Id" = @Id
                    AND c."TenantId" = @TenantId
                    """;

                    var parameters = new { Id = id, TenantId = tenantId };

                    var companyDictionary = new Dictionary<Guid, Company>();

                    var records = await _dbSession.Connection.QueryAsync<Company, Employee, Company>(
                        query,
                        (company, employee) =>
                        {
                            if (!companyDictionary.TryGetValue(company.Id, out var companyEntry))
                            {
                                companyEntry = company;
                                companyDictionary.Add(company.Id, companyEntry);
                            }

                            companyEntry.Employees.Add(employee);
                            return companyEntry;
                        },
                        parameters,
                        splitOn: "Id",
                        transaction: _dbSession.Transaction);

                    return companyDictionary.Values.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
