using SalonManager.Customers.Core.Entities;
using SalonManager.Customers.CrossCutting.Enums;

namespace SalonManager.Customers.CrossCutting.Dtos
{
    public class AppointmentDto
    {
        ////public AppointmentDto(Guid customerAppointmentId, Guid serviceAppointmentId, Guid employeeAppointmentId,
        ////    Guid userCreatorId, Guid tenantId, string details, DateTime appointmentDate)
        ////{
        ////    CustomerAppointmentId = customerAppointmentId;
        ////    ServiceAppointmentId = serviceAppointmentId;
        ////    EmployeeAppointmentId = employeeAppointmentId;

        ////    UserCreatorId = userCreatorId;
        ////    TenantId = tenantId;
        ////    Details = details;
        ////    AppointmentDate = DateTime.SpecifyKind(appointmentDate, DateTimeKind.Unspecified);

        ////    Status = EAppointmentStatus.Pendente;
        ////    Earnings = 0;
        ////    Finished = false;
        ////}

        public Guid EmployeeAppointmentId { get; set; }
        public Guid CustomerAppointmentId { get; set; }
        public Guid ServiceAppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }
        public EAppointmentStatus Status { get; set; }
        public string? Details { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentWay { get; set; }
        public double Earnings { get; set; }

        public bool Finished { get; set; }
        public DateTime? FinishedDate { get; set; }

        ////public Employee? EmployeeAppointment { get; set; }
        ////public Customer? CustomerAppointment { get; set; }
        ////public SalonService? ServiceAppointment { get; set; }

        #region BaseEntity
        public Guid Id { get; set; }
        //public DateTime CreatedAt { get; set; }

        public Guid TenantId { get; set; }
        //public Guid UserCreatorId { get; set; }

        //public DateTime UpdatedAt { get; set; }
        //public bool IsActived { get; set; }

        #endregion  
    }
}
