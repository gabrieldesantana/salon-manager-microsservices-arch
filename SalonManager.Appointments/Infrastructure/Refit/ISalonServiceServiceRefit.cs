using Refit;
using SalonManager.Appointments.CrossCutting.Dtos;

namespace SalonManager.Appointments.Infrastructure.Refit
{
    public interface ISalonServiceServiceRefit
    {
        [Get("/api/SalonServices/")]
        Task<IApiResponse<SalonServiceDto>> GetSalonServiceAsync(Guid tenantId, Guid id);
    }
}
