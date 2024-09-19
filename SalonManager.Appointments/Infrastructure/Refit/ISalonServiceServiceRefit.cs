using Refit;
using SalonManager.Appointments.CrossCutting.Dtos;

namespace SalonManager.Appointments.Infrastructure.Refit
{
    public interface ISalonServiceServiceRefit
    {
        [Get("/api/SalonServices/{tenantId}/{id}")]
        Task<IApiResponse<SalonServiceDto>> GetSalonServiceAsync([Header("Authorization")] string token, Guid tenantId, Guid id);
    }
}
