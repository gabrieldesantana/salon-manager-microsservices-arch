using SalonManager.Appointments.Core.Entities;

namespace SalonManager.Appointments.CrossCutting.Dtos
{
    public class EmployeeDto
    {

        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }

        public string? Cpf { get; set; }
        public string? FullName { get; set; }
        public string? Nickname { get; set; }
        public string? Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
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
