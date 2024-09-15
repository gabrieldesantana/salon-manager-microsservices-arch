using SalonManager.Customers.Core.Entities;
using SalonManager.Customers.CrossCutting.Enums;

namespace SalonManager.Customers.CrossCutting.Dtos
{
    public class AppointmentDto
    {
        public AppointmentDto(Guid customerAppointmentId, Guid serviceAppointmentId, Guid employeeAppointmentId,
            Guid userCreatorId, Guid tenantId, string details, DateTime appointmentDate)
        {
            CustomerAppointmentId = customerAppointmentId;
            ServiceAppointmentId = serviceAppointmentId;
            EmployeeAppointmentId = employeeAppointmentId;

            UserCreatorId = userCreatorId;
            TenantId = tenantId;
            Details = details;
            AppointmentDate = DateTime.SpecifyKind(appointmentDate, DateTimeKind.Unspecified);

            Status = EAppointmentStatus.Pendente;
            Earnings = 0;
            Finished = false;
        }

        public Guid EmployeeAppointmentId { get; private set; }
        public Guid CustomerAppointmentId { get; private set; }
        public Guid ServiceAppointmentId { get; private set; }

        public DateTime AppointmentDate { get; set; }
        public EAppointmentStatus Status { get; private set; }
        public string? Details { get; private set; }
        public string? PaymentMethod { get; private set; }
        public string? PaymentWay { get; private set; }
        public double Earnings { get; private set; }

        public bool Finished { get; private set; }
        public DateTime? FinishedDate { get; private set; }

        ////public Employee? EmployeeAppointment { get; set; }
        public Customer? CustomerAppointment { get; set; }
        ////public SalonService? ServiceAppointment { get; set; }

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
