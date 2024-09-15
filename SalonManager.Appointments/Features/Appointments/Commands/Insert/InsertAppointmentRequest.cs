using FluentResults;
using MediatR;

namespace SalonManager.Appointments.Features.Appointments.Commands.Insert
{
    public class InsertAppointmentRequest : IRequest<Result<InsertAppointmentResponse>>
    {
        public InsertAppointmentRequest(
            Guid tenantId,
            Guid userCreatorId,
            Guid customerAppointmentId,
            Guid serviceAppointmentId,
            Guid employeeAppointmentId,
            DateTime appointmentDate,
            string details)
        {
            TenantId = tenantId;
            UserCreatorId = userCreatorId;
            Details = details;

            CustomerAppointmentId = customerAppointmentId;
            ServiceAppointmentId = serviceAppointmentId;
            EmployeeAppointmentId = employeeAppointmentId;

            AppointmentDate = appointmentDate;
            Earnings = 0;
        }
        public Guid TenantId { get; private set; }
        public Guid UserCreatorId { get; private set; }

        public Guid EmployeeAppointmentId { get; private set; }
        public Guid CustomerAppointmentId { get; private set; }
        public Guid ServiceAppointmentId { get; private set; }
        public DateTime AppointmentDate { get; private set; }
        public double Earnings { get; private set; }
        public string Details { get; private set; }

    }
}
