using FluentResults;
using MediatR;

namespace SalonManager.Appointments.Features.Appointments.Commands.Finish
{
    public class FinishAppointmentRequest : IRequest<Result<FinishAppointmentResponse>>
    {
        public FinishAppointmentRequest(
            Guid id, Guid tenantId, string paymentMethod, string paymentWay,
            double earnings, string details)
        {
            Id = id;
            TenantId = tenantId;
            PaymentMethod = paymentMethod;
            PaymentWay = paymentWay;
            Earnings = earnings;
            Details = details;
        }

        public Guid Id { get; private set; }
        public string PaymentMethod { get; private set; }
        public string PaymentWay { get; private set; }
        public double Earnings { get; private set; }
        public string Details { get; private set; }
        public Guid TenantId { get; private set; }

    }
}
