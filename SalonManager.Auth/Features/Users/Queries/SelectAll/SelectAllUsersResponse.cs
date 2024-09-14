using SalonManager.Auth.Core.Entities;
using SalonManager.Auth.CrossCutting.Models;
using SalonManager.Auth.Features.Users.Queries.Select;

namespace SalonManager.Auth.Features.Users.Queries.SelectAll
{
    public class SelectAllUsersResponse
    {
        public static PagedResult<SelectUserResponse> FromUsersToPagedResult(List<User> users, int pageNumber, int pageSize, int totalRecords)
        {
            var usersResponse = users
                .Select(x => SelectUserResponse.FromUser(x))
                .ToList();

            return new PagedResult<SelectUserResponse>(usersResponse, pageNumber, pageSize, totalRecords);
        }
    }
}
