namespace SalonManager.Customers.CrossCutting.Responses
{
    public class SelectAppointmentResponse
    {

        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid EmployeeAppointmentId { get; set; }
        public Guid CustomerAppointmentId { get; set; }
        public Guid ServiceAppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Status { get; set; }

        public string? Details { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentWay { get; set; }
        public double Earnings { get; set; }

        public bool Finished { get; set; }
        public DateTime? FinishedDate { get; set; }
    }
}
