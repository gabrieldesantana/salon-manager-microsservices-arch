using FluentResults;
using MediatR;

namespace SalonManager.Auth.Features.Users.Queries.Select
{
    public record SelectUserRequest(Guid Id) : IRequest<Result<SelectUserResponse>>;
}
