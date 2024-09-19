using SalonManager.Business.Core.Entities;

namespace SalonManager.Business.Features.Employees.Commands.Update
{
    public class UpdateEmployeeResponse
    {
        public UpdateEmployeeResponse
           (Guid id,
           Guid tenantId,
           string? cpf,
           string? fullName,
           string? nickname,
           string? gender,
           DateTime birthDate,
           string? phoneNumber)
        {
            Id = id;
            TenantId = tenantId;
            Cpf = cpf;
            FullName = fullName;
            Nickname = nickname;
            Gender = gender;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public string? Cpf { get; private set; }
        public string? FullName { get; private set; }
        public string? Nickname { get; private set; }
        public string? Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? PhoneNumber { get; private set; }

        public static implicit operator UpdateEmployeeResponse(Employee employee)
            => new(
                employee.Id,
                employee.TenantId,
                employee.Cpf,
                employee.FullName,
                employee.Nickname,
                employee.Gender,
                employee.BirthDate,
                employee.PhoneNumber
                );
    }
}
