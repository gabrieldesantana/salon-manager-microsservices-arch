using FluentResults;
using MediatR;
using SalonManager.Customers.CrossCutting.Enums;
using SalonManager.Customers.CrossCutting.Responses;

namespace SalonManager.Customers.CrossCutting.Requests
{
    public class InsertUserRequest
    {
        public InsertUserRequest(string? fullName, string? login, string? email, string? password, int role)
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
        public int Role { get; private set; }
    }
}
