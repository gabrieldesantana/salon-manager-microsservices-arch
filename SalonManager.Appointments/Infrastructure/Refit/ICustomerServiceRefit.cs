using Refit;
using SalonManager.Appointments.CrossCutting.Dtos;
using SalonManager.Appointments.CrossCutting.Requests;
using SalonManager.Appointments.CrossCutting.Responses;

namespace SalonManager.Appointments.Infrastructure.Refit
{
    public interface ICustomerServiceRefit
    {
        [Get("/api/Customers/")]
        Task<IApiResponse<CustomerDto>> GetCustomerAsync(Guid tenantId, Guid id);

        [Get("/api/Customers/increase-visited-times")]
        Task<IApiResponse<IncreaseVisitedTimesResponse>> IncreaseVisitedTimes([Body] IncreaseVisitedTimesRequest request);
    }
}
