using SalonManager.Business.CrossCutting.Dtos;

namespace SalonManager.Business.Core.Entities
{
    public class Employee : BaseEntity
    {
        protected Employee()
        {
            Appointments = [];
        }

        public Employee(Guid tenantId, Guid userCreatorId, Guid userId, Guid companyId, string? cpf, string? name, string? nickname, string? gender, DateTime birthDate, string? phoneNumber)
        {
            TenantId = tenantId;
            UserCreatorId = userCreatorId;
            UserId = userId;
            CompanyId = companyId;
            Cpf = cpf;
            Name = name;
            Nickname = nickname;
            Gender = gender;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Appointments = [];
        }

        public Guid UserId { get; private set; }
        public Guid CompanyId { get; private set; }

        public string? Cpf { get; private set; }
        public string? Name { get; private set; }
        public string? Nickname { get; private set; }
        public string? Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? PhoneNumber { get; private set; }

        public UserDto? User { get; private set; }
        public Company? Company { get; set; }
        public List<AppointmentDto>? Appointments { get; set; }

        public void Update(string cpf, string name, string nickname,
           string gender, DateTime birthDate, string phoneNumber)
        {
            Cpf = cpf;
            Name = name;
            Nickname = nickname;
            Gender = gender;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            UpdatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
        }
    }
}
