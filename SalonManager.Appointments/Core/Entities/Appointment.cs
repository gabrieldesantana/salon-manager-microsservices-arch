using SalonManager.Appointments.Core.Enums;
using SalonManager.Appointments.CrossCutting.Dtos;

namespace SalonManager.Appointments.Core.Entities
{
    public class Appointment : BaseEntity
    {
        protected Appointment()
        {
        }

        public Appointment(Guid customerAppointmentId, Guid serviceAppointmentId, Guid employeeAppointmentId,
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

        public EmployeeDto? EmployeeAppointment { get; set; }
        public CustomerDto? CustomerAppointment { get; set; }
        public SalonServiceDto? ServiceAppointment { get; set; }

        public void Update(DateTime appointmentDate, string? details)
        {
            AppointmentDate = appointmentDate;
            Details = details;
            UpdatedAt = appointmentDate;
        }

        public void UpdateStatus(EAppointmentStatus status)
        {
            Status = status;
            UpdatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
        }

        public void Finish(string? paymentMethod, string? paymentWay, double earnings, string? details)
        {
            PaymentMethod = paymentMethod;
            PaymentWay = paymentWay;
            Earnings = earnings;
            Details = details;
            Status = EAppointmentStatus.Finalizado;
            Finished = true;
            FinishedDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
        }

        public void ValidateStatus()
        {
            var isPending = DateTime.Now < AppointmentDate;

            if (Status == EAppointmentStatus.Pendente)
            {
                this.Status = (AppointmentDate <= DateTime.Now) ? EAppointmentStatus.Iniciado : Status;
            }
            else if (Status == EAppointmentStatus.Iniciado)
            {
                this.Status = (AppointmentDate >= DateTime.Now) ? EAppointmentStatus.Pendente : Status;
            }
        }
    }
}
