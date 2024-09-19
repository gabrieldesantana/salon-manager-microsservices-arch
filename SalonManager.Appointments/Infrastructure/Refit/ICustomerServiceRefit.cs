using Refit;
using SalonManager.Appointments.CrossCutting.Dtos;
using SalonManager.Appointments.CrossCutting.Requests;
using SalonManager.Appointments.CrossCutting.Responses;

namespace SalonManager.Appointments.Infrastructure.Refit
{
    public interface ICustomerServiceRefit
    {
        [Headers]
        [Get("/api/Customers/{tenantId}/{id}")]
        Task<IApiResponse<CustomerDto>> GetCustomerAsync([Header("Authorization")] string token, Guid tenantId, Guid id);

        [Get("/api/Customers/increase-visited-times")]
        Task<IApiResponse<IncreaseVisitedTimesResponse>> IncreaseVisitedTimes([Header("Authorization")] string token, [Body] IncreaseVisitedTimesRequest request);
    }
}
