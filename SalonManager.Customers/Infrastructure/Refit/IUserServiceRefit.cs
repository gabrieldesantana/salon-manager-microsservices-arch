using Refit;
using SalonManager.Customers.CrossCutting.Requests;
using SalonManager.Customers.CrossCutting.Responses;

namespace SalonManager.Customers.Infrastructure.Refit
{
    public interface IUserServiceRefit
    {
        [Post("/api/Users/")]
        [Headers("Content-type: application/json")]
        Task<IApiResponse<InsertUserResponse>> InsertUserAsync([Header("Authorization")] string token, [Body] InsertUserRequest request);

        [Put("/api/Users/activate-user")]
        [Headers("Content-type: application/json")]
        Task<IApiResponse<ActivateUserResponse>> ActivateUserAsync([Header("Authorization")] string token, [Body] ActivateUserRequest request);
    }
}
