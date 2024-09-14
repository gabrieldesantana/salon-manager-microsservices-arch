using FluentResults;
using MediatR;

namespace SalonManager.Auth.Features.Auth.Commands.Login
{
    public class LoginUserRequest : IRequest<Result<LoginUserResponse>>
    {
        public LoginUserRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
