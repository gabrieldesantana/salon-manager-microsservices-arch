using Refit;
using SalonManager.Customers.CrossCutting.Responses;

namespace SalonManager.Customers.Infrastructure.Refit
{
    public interface IAppointmentServiceRefit
    {
        [Headers("accept: application/json")]
        [Get("/api/Appointments/customer/{tenantId}/{customerId}")]
        Task<IApiResponse<SelectAllAppointmentsByCustomerIdResponse>> GetAppointmentsByCustomerAsync([Header("Authorization")] string token, Guid tenantId, Guid customerId);
    }
}
