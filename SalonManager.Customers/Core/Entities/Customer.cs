using SalonManager.Customers.CrossCutting.Dtos;

namespace SalonManager.Customers.Core.Entities
{
    public class Customer : BaseEntity
    {
        protected Customer()
        {
            Appointments = [];
        }

        public Customer(Guid tenantId, Guid userCreatorId, Guid userId,
        string? cpf, string? fullName, string? nickname,
        string? gender, DateTime birthDate, string? phoneNumber)
        {
            TenantId = tenantId;
            UserCreatorId = userCreatorId;
            UserId = userId;

            Cpf = cpf;
            FullName = fullName;
            Nickname = nickname;
            Gender = gender;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;

            Appointments = new List<AppointmentDto>();
        }
        public Guid UserId { get; private set; }

        public string? Cpf { get; private set; }
        public string? FullName { get; private set; }
        public string? Nickname { get; private set; }
        public string? Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? PhoneNumber { get; private set; }

        public string? LastServiceName { get; private set; }
        public DateTime LastServiceDate { get; private set; }
        public int TimesVisited { get; private set; }
        public UserDto? User { get; private set; }
        public List<AppointmentDto>? Appointments { get; set; }

        public void Update(string cpf, string fullName, string nickname,
            string gender, DateTime birthDate, string phoneNumber)
        {
            Cpf = cpf;
            FullName = fullName;
            Nickname = nickname;
            Gender = gender;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            UpdatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
        }
        public void IncreaseVisitedTimes(string lastServiceName, DateTime lastServiceDate)
        {
            LastServiceName = lastServiceName;
            LastServiceDate = DateTime.SpecifyKind(lastServiceDate, DateTimeKind.Unspecified);
            UpdatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            this.TimesVisited += 1;
        }
    }
}
