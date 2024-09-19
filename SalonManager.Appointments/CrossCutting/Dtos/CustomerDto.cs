using SalonManager.Appointments.Core.Entities;

namespace SalonManager.Appointments.CrossCutting.Dtos
{
    public class CustomerDto
    {
        public CustomerDto(Guid tenantId, Guid userCreatorId, Guid userId,
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

            ////Appointments = [];
        }
        public Guid UserId { get; set; }

        public string? Cpf { get; set; }
        public string? FullName { get; set; }
        public string? Nickname { get; set; }
        public string? Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PhoneNumber { get; set; }

        public string? LastServiceName { get; set; }
        public DateTime LastServiceDate { get; set; }
        public int TimesVisited { get; set; }
        ////public List<Appointment>? Appointments { get; set; }

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
