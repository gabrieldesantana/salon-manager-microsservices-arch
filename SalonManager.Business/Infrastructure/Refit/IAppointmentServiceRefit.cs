using Refit;
using SalonManager.Business.CrossCutting.Responses;

namespace SalonManager.Business.Infrastructure.Refit
{
    public interface IAppointmentServiceRefit
    {

        [Get("/api/Appointments/employee/{tenantId}/{employeeId}")]
        Task<IApiResponse<SelectAllAppointmentsByEmployeeIdResponse>> GetAppointmentsByEmployeeAsync(Guid tenantId, Guid employeeId);
    }
}
