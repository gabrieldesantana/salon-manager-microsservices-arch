using SalonManager.Business.Core.Entities;
using SalonManager.Business.CrossCutting.Dtos;

namespace SalonManager.Business.Features.Employees.Queries.Select
{
    public class SelectEmployeeResponse
    {
        public SelectEmployeeResponse(Guid id, Guid tenantId, Guid userId,
            Guid companyId, string? cpf, string? fullName,
            string? nickname, string? gender, DateTime birthDate,
            string? phoneNumber, List<AppointmentDto>? appointments)
        {
            Id = id;
            TenantId = tenantId;
            UserId = userId;
            CompanyId = companyId;
            Cpf = cpf;
            FullName = fullName;
            Nickname = nickname;
            Gender = gender;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Appointments = appointments;
        }

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid CompanyId { get; private set; }

        public string? Cpf { get; private set; }
        public string? FullName { get; private set; }
        public string? Nickname { get; private set; }
        public string? Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? PhoneNumber { get; private set; }

        public List<AppointmentDto>? Appointments { get; set; }

        public const bool INCLUDEOBJECTS = true;

        public static SelectEmployeeResponse FromEmployee(Employee employee, bool includeObjects)
            => new(
                employee.Id,
                employee.TenantId,
                employee.UserId,
                employee.CompanyId,
                employee.Cpf,
                employee.FullName,
                employee.Nickname,
                employee.Gender,
                employee.BirthDate,
                employee.PhoneNumber,
                (includeObjects) ? employee.Appointments : null
                );

        public static implicit operator SelectEmployeeResponse(Employee employee)
            => new(
                employee.Id,
                employee.TenantId,
                employee.UserId,
                employee.CompanyId,
                employee.Cpf,
                employee.FullName,
                employee.Nickname,
                employee.Gender,
                employee.BirthDate,
                employee.PhoneNumber,
                (INCLUDEOBJECTS) ? employee.Appointments : null
                );
    }
}
