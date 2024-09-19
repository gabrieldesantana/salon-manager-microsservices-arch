using FluentResults;
using MediatR;

namespace SalonManager.Auth.Features.Users.Commands.ActivateUser
{
    public class ActivateUserRequest : IRequest<Result<ActivateUserResponse>>
    {
        public ActivateUserRequest(Guid id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
    }
}
