using SalonManager.Auth.Core.Entities;
using SalonManager.Auth.Core.Enums;

namespace SalonManager.Auth.Features.Users.Commands.Insert
{
    public class InsertUserResponse
    {
        public InsertUserResponse(Guid id, string? fullName, string? login, string? email, EUserRole role)
        {
            Id = id;
            FullName = fullName;
            Login = login;
            Email = email;
            Role = role;
        }

        public Guid Id { get; private set; }
        public string? FullName { get; private set; }
        public string? Login { get; private set; }
        public string? Email { get; private set; }
        public EUserRole Role { get; private set; }

        public static implicit operator InsertUserResponse(User user)
            => new(
                user.Id,
                user.FullName,
                user.Login,
                user.Email,
                user.Role
                );
    }
}
