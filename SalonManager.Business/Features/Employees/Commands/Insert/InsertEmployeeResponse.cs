using SalonManager.Business.Core.Entities;

namespace SalonManager.Business.Features.Employees.Commands.Insert
{
    public class InsertEmployeeResponse
    {
        public InsertEmployeeResponse(Guid id, Guid tenantId,Guid companyId, string? cpf, string? name,
      string? nickname, string? gender, DateTime birthDate, string? phoneNumber)
        {
            Id = id;
            TenantId = tenantId;
            CompanyId = companyId;
            Cpf = cpf;
            Name = name;
            Nickname = nickname;
            Gender = gender;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public Guid CompanyId { get; private set; }

        public string? Cpf { get; private set; }
        public string? Name { get; private set; }
        public string? Nickname { get; private set; }
        public string? Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? PhoneNumber { get; private set; }

        public static implicit operator InsertEmployeeResponse(Employee employee)
            => new(
                employee.Id,
                employee.TenantId,
                employee.CompanyId,
                employee.Cpf,
                employee.Name,
                employee.Nickname,
                employee.Gender,
                employee.BirthDate,
                employee.PhoneNumber
                );
    }
}
