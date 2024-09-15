using SalonManager.Appointments.Core.Entities;
using SalonManager.Appointments.Core.Enums;

namespace SalonManager.Appointments.Features.Appointments.Commands.Insert
{
    public class InsertAppointmentResponse
    {
        public InsertAppointmentResponse(
            Guid tenantId,
            Guid userCreatorId,
            Guid customerAppointmentId,
            Guid serviceAppointmentId,
            Guid employeeAppointmentId,
            DateTime appointmentDate,
            EAppointmentStatus status,
            bool finished
            )
        {
            TenantId = tenantId;
            UserCreatorId = userCreatorId;

            CustomerAppointmentId = customerAppointmentId;
            ServiceAppointmentId = serviceAppointmentId;
            EmployeeAppointmentId = employeeAppointmentId;

            AppointmentDate = appointmentDate;
            Status = status;
            Finished = finished;
        }
        public Guid TenantId { get; private set; }

        public Guid EmployeeAppointmentId { get; private set; }
        public Guid CustomerAppointmentId { get; private set; }
        public Guid ServiceAppointmentId { get; private set; }
        public DateTime AppointmentDate { get; private set; }
        public EAppointmentStatus Status { get; private set; }

        public bool Finished { get; private set; }
        public Guid UserCreatorId { get; private set; }

        public static implicit operator InsertAppointmentResponse(Appointment appointment)
            => new(
                appointment.TenantId,
                appointment.UserCreatorId,
                appointment.CustomerAppointmentId,
                appointment.ServiceAppointmentId,
                appointment.EmployeeAppointmentId,
                appointment.AppointmentDate,
                appointment.Status,
                appointment.Finished
                );
    }
}
