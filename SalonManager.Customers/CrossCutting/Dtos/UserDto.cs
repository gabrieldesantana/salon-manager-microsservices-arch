using SalonManager.Customers.Core.Entities;
using SalonManager.Customers.CrossCutting.Enums;

namespace SalonManager.Customers.CrossCutting.Dtos
{
    public class UserDto : BaseEntity
    {
        public UserDto(string? fullName, string? login, string? email,
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
    }
}
