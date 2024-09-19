using SalonManager.Business.CrossCutting.Enums;

namespace SalonManager.Business.CrossCutting.Dtos
{
    public class UserDto
    {
        ////public UserDto(string? fullName, string? login, string? email,
        ////    string? password, EUserRole role)
        ////{
        ////    FullName = fullName;
        ////    Login = login;
        ////    Email = email;
        ////    Password = password;
        ////    Role = role;
        ////    InUse = false;
        ////    InUseBy = string.Empty;
        ////}

        public string? FullName { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public EUserRole Role { get; set; }

        public bool InUse { get; set; }
        public string InUseBy { get; set; }

        #region BaseEntity
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid TenantId { get; set; }
        public Guid UserCreatorId { get; set; }

        public DateTime UpdatedAt { get; set; }
        public bool IsActived { get; set; }

        #endregion  
    }
}
