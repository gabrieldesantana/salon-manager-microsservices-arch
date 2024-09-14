using SalonManager.Auth.Core.Entities;

namespace SalonManager.Auth.Features.Users.Commands.Update
{
    public class UpdateUserResponse
    {
        public UpdateUserResponse(Guid id, string? fullName, string? login, string? email)
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

        public static implicit operator UpdateUserResponse(User user)
            => new(
                user.Id,
                user.FullName,
                user.Login,
                user.Email
                );
    }
}
