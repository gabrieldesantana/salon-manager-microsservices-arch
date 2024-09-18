using Dapper;
using SalonManager.Appointments.Core.Entities;
using SalonManager.Appointments.Core.Enums;
using SalonManager.Appointments.Core.Interfaces.Repositories;
using SalonManager.Appointments.Infrastructure.Context;

namespace SalonManager.Appointments.Infrastructure.Repositories
{
    public class AppointmentQueryRepository : IAppointmentQueryRepository
    {
        private DbSession _dbSession;

        public AppointmentQueryRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<List<Appointment>> GetAllAsync(Guid tenantId, int pageNumber, int pageSize)
        {
            try
            {
                var query = """
                            SELECT app.*
                            FROM "Appointments" app
                            WHERE app."IsActived" = true
                            AND app."TenantId" = @TenantId
                            ORDER BY app."Id"
                            LIMIT @PageSize OFFSET @PageSize * (@PageNumber - 1);
                            """;

                var parameters = new { PageNumber = pageNumber, PageSize = pageSize, TenantId = tenantId };

                var records = await _dbSession.Connection.QueryAsync<Appointment>(
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

        public async Task<List<Appointment>> GetAllByCustomerIdAsync(Guid customerId, Guid tenantId)
        {
            try
            {
                var query = """
                            SELECT app.*
                            FROM "Appointments" app
                            WHERE app."IsActived" = True
                            AND app."CustomerAppointmentId" = @CustomerId AND app."TenantId" = @TenantId
                            """;

                var parameters = new { CustomerId = customerId, TenantId = tenantId };

                var appointments = await _dbSession.Connection.QueryAsync<Appointment>(
                    query,
                    parameters,
                    transaction: _dbSession.Transaction);

                return appointments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Appointment>> GetAllByEmployeeIdAsync(Guid employeeId, Guid tenantId)
        {
            try
            {
                var query = """
                            SELECT app.*
                            FROM "Appointments" app
                            WHERE app."IsActived" = True
                            AND app."EmployeeAppointmentId" = @EmployeeId AND app."TenantId" = @TenantId
                            """;

                var parameters = new { EmployeeId = employeeId, TenantId = tenantId };

                var appointments = await _dbSession.Connection.QueryAsync<Appointment>(
                    query,
                    parameters,
                    transaction: _dbSession.Transaction);

                return appointments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Appointment> GetByIdAsync(Guid id, Guid tenantId)
        {
            try
            {
                var query = """
                            SELECT app.*
                            FROM "Appointments" app
                            WHERE app."IsActived" = True
                            AND app."Id" = @Id AND app."TenantId" = @TenantId
                            """;

                var parameters = new { Id = id, TenantId = tenantId };

                var appointment = await _dbSession.Connection.QueryFirstAsync<Appointment>
                (
                query,
                parameters,
                transaction: _dbSession.Transaction
                );

                return appointment;

                ////var query = """
                ////            SELECT app.*, ca."Id" AS CustomerId, ca.*, sa."Id" AS ServiceId, sa.*, ea."Id" AS EmployeeId, ea.*
                ////            FROM "Appointments" app
                ////            LEFT JOIN "Customers" ca ON app."CustomerAppointmentId" = ca."Id"
                ////            LEFT JOIN "SalonServices" sa ON app."ServiceAppointmentId" = sa."Id"
                ////            LEFT JOIN "Employees" ea ON app."EmployeeAppointmentId" = ea."Id"
                ////            WHERE app."IsActived" = True
                ////            AND app."Id" = @Id AND app."TenantId" = @TenantId
                ////            """;

                ////var parameters = new { Id = id, TenantId = tenantId };

                ////var appointments = await _dbSession.Connection.QueryAsync<Appointment, Customer, SalonService, Employee, Appointment>
                ////(
                ////query,
                ////(appointment, customerAppointment, serviceAppointment, employeeAppointment) =>
                ////{
                ////    appointment.CustomerAppointment = customerAppointment;
                ////    appointment.ServiceAppointment = serviceAppointment;
                ////    appointment.EmployeeAppointment = employeeAppointment;
                ////    return appointment;
                ////},
                ////parameters,
                ////splitOn: "CustomerId,ServiceId,EmployeeId",
                ////transaction: _dbSession.Transaction
                ////);

                ////return appointments.FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        ////public async Task<Appointment> GetByIdClean(Guid id, Guid tenantId)
        ////{
        ////    try
        ////    {
        ////        var query = """
        ////                    SELECT app.*
        ////                    FROM "Appointments" app
        ////                    WHERE app."IsActived" = True
        ////                    AND app."Id" = @id AND app."TenantId" = @tenantId
        ////                    """;

        ////        var parameters = new { Id = id, TenantId = tenantId };

        ////        var result = await _dbSession.Connection.QueryAsync<Appointment>
        ////            (
        ////            query,
        ////            parameters
        ////            );

        ////        return result.FirstOrDefault();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        throw new Exception(ex.Message, ex);
        ////    }
        ////}

        public async Task<List<Appointment>> GetAllFinishedByDateAsync(Guid tenantId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var startDateFormated = DateTime.SpecifyKind(startDate, DateTimeKind.Unspecified);
                var endDateFormated = DateTime.SpecifyKind(endDate, DateTimeKind.Unspecified);

                var query = """
                    SELECT app.*
                    FROM "Appointments" app
                    WHERE app."IsActived" = True
                    AND app."AppointmentDate" >= @StartDate
                    AND app."AppointmentDate" <= @EndDate
                    AND app."Status" = @Status
                    AND app."TenantId" = @TenantId 
                    """;

                var parameters = new
                {
                    StartDate = startDateFormated,
                    EndDate = endDateFormated,
                    Status = nameof(EAppointmentStatus.Pendente),
                    TenantId = tenantId
                };

                var appointments = await _dbSession.Connection.QueryAsync<Appointment>(
                    query,
                    parameters,
                    transaction: _dbSession.Transaction
                );

                return appointments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
