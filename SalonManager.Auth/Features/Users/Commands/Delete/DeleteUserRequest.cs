using FluentResults;
using MediatR;

namespace SalonManager.Auth.Features.Users.Commands.Delete
{
    public record DeleteUserRequest(Guid Id) : IRequest<Result<DeleteUserResponse>>;
}
