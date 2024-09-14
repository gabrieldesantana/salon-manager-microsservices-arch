using Refit;
using SalonManager.Customers.CrossCutting.Requests;
using SalonManager.Customers.CrossCutting.Responses;

namespace SalonManager.Customers.Infrastructure.Refit
{
    public interface IUserServiceRefit
    {
        [Post("/api/Users/")]
        [Headers("Content-type: application/json")]
        Task<IApiResponse<InsertUserResponse>> InsertUserAsync([Body] InsertUserRequest request);

        [Get("/api/Users/")]
        Task<IApiResponse<InsertUserResponse>> GetUsersAsync([Query] int pageNumber, [Query] int pageSize);
    }
}
