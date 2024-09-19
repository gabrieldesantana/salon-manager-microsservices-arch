using SalonManager.Auth.Core.Entities;

namespace SalonManager.Auth.Features.Users.Commands.ActivateUser
{
    public class ActivateUserResponse
    {
        public ActivateUserResponse(Guid id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }

        public static implicit operator ActivateUserResponse(User user)
            => new(
                user.Id,
                user.FullName
                );
    }
}
