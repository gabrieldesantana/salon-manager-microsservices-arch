namespace SalonManager.Appointments.CrossCutting.Responses
{
    public class IncreaseVisitedTimesResponse
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string LastServiceName { get; set; }
        public DateTime LastServiceDate { get; set; }
    }
}
