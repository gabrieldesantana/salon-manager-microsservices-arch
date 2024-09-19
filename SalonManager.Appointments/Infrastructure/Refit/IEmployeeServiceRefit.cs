using Refit;
using SalonManager.Appointments.CrossCutting.Dtos;

namespace SalonManager.Appointments.Infrastructure.Refit
{
    public interface IEmployeeServiceRefit
    {
        [Get("/api/Employees/{tenantId}/{id}")]
        Task<IApiResponse<EmployeeDto>> GetEmployeeAsync([Header("Authorization")] string token, Guid tenantId, Guid id);
    }
}
