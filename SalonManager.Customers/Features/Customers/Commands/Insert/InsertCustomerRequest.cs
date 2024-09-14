using FluentResults;
using MediatR;
using SalonManager.Customers.CrossCutting.Dtos;

namespace SalonManager.Customers.Features.Customers.Commands.Insert
{
    public class InsertCustomerRequest : IRequest<Result<InsertCustomerResponse>>
    {
        public InsertCustomerRequest(
        Guid tenantId, Guid userCreatorId,
        string? cpf, string? fullName, string? nickname,
        string? gender, DateTime birthDate, string? phoneNumber, string? email)
        {
            TenantId = tenantId;
            UserCreatorId = userCreatorId;

            Cpf = cpf;
            FullName = fullName;
            Nickname = nickname;
            Gender = gender;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;

            Appointments = [];
        }

        public Guid TenantId { get; private set; }
        public Guid UserCreatorId { get; private set; }

        public string? Cpf { get; private set; }
        public string? FullName { get; private set; }
        public string? Nickname { get; private set; }
        public string? Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string? Email { get; private set; }

        public List<AppointmentDto> Appointments { get; private set; }
    }
}
