namespace SalonManager.Appointments.CrossCutting.Requests
{
    public class IncreaseVisitedTimesRequest
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string LastServiceName { get; set; }
        public DateTime LastServiceDate { get; set; }
    }
}
