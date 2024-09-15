using Refit;
using SalonManager.Appointments.CrossCutting.Dtos;

namespace SalonManager.Appointments.Infrastructure.Refit
{
    public interface IEmployeeServiceRefit
    {
        [Get("/api/Employees/")]
        Task<IApiResponse<EmployeeDto>> GetEmployeeAsync(Guid tenantId, Guid id);
    }
}
