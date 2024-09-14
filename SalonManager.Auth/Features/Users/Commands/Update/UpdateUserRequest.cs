using FluentResults;
using MediatR;

namespace SalonManager.Auth.Features.Users.Commands.Update
{
    public class UpdateUserRequest : IRequest<Result<UpdateUserResponse>>
    {
        public UpdateUserRequest(Guid id, string? fullName, string? login, string? email)
        {
            Id = id;
            FullName = fullName;
            Login = login;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string? FullName { get; private set; }
        public string? Login { get; private set; }
        public string? Email { get; private set; }
    }
}
