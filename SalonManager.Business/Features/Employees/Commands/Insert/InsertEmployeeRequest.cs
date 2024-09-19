using FluentResults;
using MediatR;

namespace SalonManager.Business.Features.Employees.Commands.Insert
{
    public class InsertEmployeeRequest : IRequest<Result<InsertEmployeeResponse>>
    {
        public InsertEmployeeRequest(
            Guid tenantId,
            Guid userCreatorId,
            Guid userId,
            Guid companyId,
            string? cpf,
            string? fullName,
            string? nickname,
            string? gender,
            DateTime birthDate,
            string? phoneNumber)
        {
            TenantId = tenantId;
            UserCreatorId = userCreatorId;
            UserId = userId;
            CompanyId = companyId;
            Cpf = cpf;
            FullName = fullName;
            Nickname = nickname;
            Gender = gender;
            BirthDate = DateTime.SpecifyKind(birthDate, DateTimeKind.Unspecified);
            PhoneNumber = phoneNumber;
        }

        public Guid TenantId { get; private set; }
        public Guid UserCreatorId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid CompanyId { get; private set; }

        public string? Cpf { get; private set; }
        public string? FullName { get; private set; }
        public string? Nickname { get; private set; }
        public string? Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? PhoneNumber { get; private set; }
    }
}
