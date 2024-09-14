using FluentResults;
using MediatR;
using SalonManager.Auth.CrossCutting.Models;
using SalonManager.Auth.Features.Users.Queries.Select;

namespace SalonManager.Auth.Features.Users.Queries.SelectAll
{
    public record SelectAllUsersRequest(int PageNumber, int PageSize) : IRequest<Result<PagedResult<SelectUserResponse>>>;
}
