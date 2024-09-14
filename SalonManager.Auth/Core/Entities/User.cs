using SalonManager.Auth.Core.Enums;

namespace SalonManager.Auth.Core.Entities
{
    public class User : BaseEntity
    {
        protected User() { }
        public User(string? fullName, string? login, string? email,
            string? password, EUserRole role)
        {
            FullName = fullName;
            Login = login;
            Email = email;
            Password = password;
            Role = role;
            InUse = false;
            InUseBy = string.Empty;
        }

        public string? FullName { get; private set; }
        public string? Login { get; private set; }
        public string? Email { get; private set; }
        public string? Password { get; private set; }
        public EUserRole Role { get; private set; }

        public bool InUse { get; private set; }
        public string InUseBy { get; private set; }

        public void ActivateUser(string username)
        {
            if (!InUse)
            {
                InUse = true;
                InUseBy = username;
            }
        }

        public void Update(string fullName, string login, string email)
        {
            FullName = fullName;
            Login = login;
            Email = email;
            UpdatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
        }

        public void ChangePassword(string password)
        {
            Password = password;
            UpdatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
        }
    }
}
