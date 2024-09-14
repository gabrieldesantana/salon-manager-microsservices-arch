using SalonManager.Auth.Core.Entities;
using SalonManager.Auth.Core.Enums;

namespace SalonManager.Auth.Features.Users.Queries.Select
{
    public class SelectUserResponse
    {
        public SelectUserResponse(Guid id, string? fullName, string? login, string? email, EUserRole role)
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

        public static SelectUserResponse FromUser(User user)
           => new(
            user.Id,
            user.FullName,
            user.Login,
            user.Email,
            user.Role
            );

        public static implicit operator SelectUserResponse(User user)
            => new(
                user.Id,
                user.FullName,
                user.Login,
                user.Email,
                user.Role
                );
    }
}
