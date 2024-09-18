using Dapper;
using SalonManager.Business.Core.Entities;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.Infrastructure.Context;

namespace SalonManager.Business.Infrastructure.Repositories
{
    public class EmployeeQueryRepository : IEmployeeQueryRepository
    {
        private DbSession _dbSession;
        public EmployeeQueryRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<List<Employee>> GetAllAsync(Guid tenantId, int pageNumber, int pageSize)
        {
            try
            {
                string query = """
                    SELECT e.*
                    FROM "Employees" e
                    WHERE "IsActived" = true AND "TenantId" = @TenantId
                    ORDER BY e."Id"
                    LIMIT @PageSize OFFSET @PageSize *(@PageNumber - 1);
                    """;

                var parameters = new { PageNumber = pageNumber, PageSize = pageSize, TenantId = tenantId };


                var records = await _dbSession.Connection.QueryAsync<Employee>(
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

        public async Task<Employee> GetByIdAsync(Guid id, Guid tenantId)
        {
            string query = """
                            SELECT e.*, c.*
                            FROM "Employees" e
                            LEFT JOIN "Companies" c ON e."CompanyId" = c."Id" AND c."IsActived" = true
                            WHERE e."Id" = @Id
                            AND e."TenantId" = @TenantId
                          """;

            var parameters = new { Id = id, TenantId = tenantId };

            var employeeDictionary = new Dictionary<Guid, Employee>();

            var records = await _dbSession.Connection.QueryAsync<Employee, Company, Employee>(
            query,
            (employee, company) =>
            {
                if (!employeeDictionary.TryGetValue(employee.Id, out var employeeEntry))
                {
                    employeeEntry = employee;
                    employeeEntry.Company = company;
                    employeeDictionary.Add(employee.Id, employeeEntry);
                }

                return employeeEntry;
            },
                parameters,
                splitOn: "Id",
                transaction: _dbSession.Transaction
            );

            return employeeDictionary.Values.FirstOrDefault();

            ////string query = """
            ////                SELECT e.*, app.*, c.*
            ////                FROM "Employees" e
            ////                LEFT JOIN "Appointments" app ON e."Id" = app."EmployeeAppointmentId" AND app."IsActived" = true
            ////                LEFT JOIN "Companies" c ON e."CompanyId" = c."Id" AND c."IsActived" = true
            ////                WHERE e."Id" = @Id
            ////                AND e."TenantId" = @TenantId
            ////              """;

            ////var parameters = new { Id = id, TenantId = tenantId };

            ////var employeeDictionary = new Dictionary<Guid, Employee>();

            ////var records = await _dbSession.Connection.QueryAsync<Employee, Appointment, Company, Employee>(
            ////query,
            ////(employee, appointment, company) =>
            ////{
            ////    if (!employeeDictionary.TryGetValue(employee.Id, out var employeeEntry))
            ////    {
            ////        employeeEntry = employee;
            ////        employeeEntry.Company = company;
            ////        employeeDictionary.Add(employee.Id, employeeEntry);
            ////    }
            ////    if (appointment != null)
            ////        employeeEntry.Appointments.Add(appointment);

            ////    return employeeEntry;
            ////},
            ////parameters,
            ////splitOn: "Id",
            ////transaction: _dbSession.Transaction
            ////);

            ////return employeeDictionary.Values.FirstOrDefault();
        }

        public async Task<Employee> GetByIdCleanAsync(Guid id, Guid tenantId)
        {
            try
            {
                string query = """
                    SELECT e.*
                    FROM "Employees" e
                    WHERE e."IsActived" = true 
                    AND e."Id" = @Id
                    AND e."TenantId" = @TenantId
                    """;

                var parameters = new { Id = id, TenantId = tenantId };

                var record = await _dbSession.Connection.QueryFirstAsync<Employee>(
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
