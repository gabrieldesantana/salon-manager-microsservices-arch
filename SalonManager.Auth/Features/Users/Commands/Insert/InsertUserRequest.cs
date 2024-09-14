using FluentResults;
using MediatR;
using SalonManager.Auth.Core.Enums;

namespace SalonManager.Auth.Features.Users.Commands.Insert
{
    public class InsertUserRequest : IRequest<Result<InsertUserResponse>>
    {
        public InsertUserRequest(string? fullName, string? login, string? email, string? password, EUserRole role)
        {
            FullName = fullName;
            Login = login;
            Email = email;
            Password = password;
            Role = role;
        }

        public string? FullName { get; private set; }
        public string? Login { get; private set; }
        public string? Email { get; private set; }
        public string? Password { get; private set; }
        public EUserRole Role { get; private set; }
    }
}
