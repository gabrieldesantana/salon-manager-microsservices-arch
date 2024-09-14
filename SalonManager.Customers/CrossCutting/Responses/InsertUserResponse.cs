using SalonManager.Customers.CrossCutting.Enums;

namespace SalonManager.Customers.CrossCutting.Responses
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
    }
}
