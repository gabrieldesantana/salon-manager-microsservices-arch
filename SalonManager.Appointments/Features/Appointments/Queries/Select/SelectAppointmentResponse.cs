using SalonManager.Appointments.Core.Entities;
using SalonManager.Appointments.CrossCutting.Dtos;

namespace SalonManager.Appointments.Features.Appointments.Queries.Select
{
    public class SelectAppointmentResponse
    {
        public SelectAppointmentResponse(
            Guid id,
            Guid tenantId,
            Guid employeeAppointmentId, Guid customerAppointmentId, Guid serviceAppointmentId,
            DateTime appointmentDate, string? status, string? details,
            string? paymentMethod, string? paymentWay, double earnings, bool finished, DateTime? finishedDate, 

            CustomerDto? customerAppointment,
            SalonServiceDto? serviceAppointment,
            EmployeeDto? employeeAppointment)
        {
            Id = id;
            TenantId = tenantId;
            EmployeeAppointmentId = employeeAppointmentId;
            CustomerAppointmentId = customerAppointmentId;
            ServiceAppointmentId = serviceAppointmentId;
            AppointmentDate = appointmentDate;
            Status = status;
            Details = details;
            PaymentMethod = paymentMethod;
            PaymentWay = paymentWay;
            Earnings = earnings;
            Finished = finished;
            FinishedDate = finishedDate;
            CustomerAppointment = customerAppointment;
            ServiceAppointment = serviceAppointment;
            EmployeeAppointment = employeeAppointment;
        }

        public const bool INCLUDEOBJECTS = true;

        public static implicit operator SelectAppointmentResponse(Appointment appointment)
        => new(
        appointment.Id,
        appointment.TenantId,
        appointment.EmployeeAppointmentId,
        appointment.CustomerAppointmentId,
        appointment.ServiceAppointmentId,
        appointment.AppointmentDate,
        appointment.Status.ToString(),
        appointment.Details,
        appointment.PaymentMethod,
        appointment.PaymentWay,
        appointment.Earnings,
        appointment.Finished,
        appointment.FinishedDate,
        (INCLUDEOBJECTS) ? appointment.CustomerAppointment : null,
        (INCLUDEOBJECTS) ? appointment.ServiceAppointment : null,
        (INCLUDEOBJECTS) ? appointment.EmployeeAppointment : null
        );

        public static SelectAppointmentResponse FromAppointment(Appointment appointment, bool includeObjects)
            => new(
                appointment.Id,
                appointment.TenantId,
                appointment.EmployeeAppointmentId,
                appointment.CustomerAppointmentId,
                appointment.ServiceAppointmentId,
                appointment.AppointmentDate,
                appointment.Status.ToString(),
                appointment.Details,
                appointment.PaymentMethod,
                appointment.PaymentWay,
                appointment.Earnings,
                appointment.Finished,
                appointment.FinishedDate,
                (includeObjects) ? appointment.CustomerAppointment : null,
                (includeObjects) ? appointment.ServiceAppointment : null,
                (includeObjects) ? appointment.EmployeeAppointment : null
                );

        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public Guid EmployeeAppointmentId { get; private set; }
        public Guid CustomerAppointmentId { get; private set; }
        public Guid ServiceAppointmentId { get; private set; }
        public DateTime AppointmentDate { get; private set; }
        public string? Status { get; private set; }

        public string? Details { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentWay { get; set; }
        public double Earnings { get; set; }

        public bool Finished { get; private set; }
        public DateTime? FinishedDate { get; private set; }

        public EmployeeDto? EmployeeAppointment { get; set; }
        public CustomerDto? CustomerAppointment { get; set; }
        public SalonServiceDto? ServiceAppointment { get; set; }
    }
}
