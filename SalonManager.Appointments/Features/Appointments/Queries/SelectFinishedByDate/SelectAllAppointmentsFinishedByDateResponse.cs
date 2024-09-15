using SalonManager.Appointments.Core.Entities;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectFinishedByDate
{
    public class SelectAllAppointmentsFinishedByDateResponse
    {
        public SelectAllAppointmentsFinishedByDateResponse(List<Appointment>? appointments, double total, DateTime startDate, DateTime endDate, string? startDateString, string? endDateString)
        {
            Appointments = appointments;
            Total = total;
            StartDate = startDate;
            EndDate = endDate;
            StartDateString = startDateString;
            EndDateString = endDateString;
        }
        public List<Appointment>? Appointments { get; private set; }
        public double Total { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string? StartDateString { get; private set; }
        public string? EndDateString { get; private set; }
    }
}
