using Refit;
using SalonManager.Business.CrossCutting.Requests;
using SalonManager.Business.CrossCutting.Responses;

namespace SalonManager.Business.Infrastructure.Refit
{
    public interface IUserServiceRefit
    {
        [Put("/api/Users/activate-user")]
        [Headers("Content-type: application/json", "accept: application/json")]
        Task<IApiResponse<ActivateUserResponse>> ActivateUserAsync([Header("Authorization")] string token, [Body] ActivateUserRequest request);
    }
}
