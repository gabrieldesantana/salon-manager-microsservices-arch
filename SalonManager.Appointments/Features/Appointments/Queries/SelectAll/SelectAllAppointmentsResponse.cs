using SalonManager.Appointments.Core.Entities;
using SalonManager.Appointments.CrossCutting.Models;
using SalonManager.Appointments.Features.Appointments.Queries.Select;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectAll
{
    public class SelectAllAppointmentsResponse
    {
        private const bool INCLUDEOBJECTS = false;

        public static PagedResult<SelectAppointmentResponse> FromAppointmentsToPagedResult(List<Appointment> appointments, int pageNumber, int pageSize, int totalRecords)
        {
            var appointmentsResponse = appointments
                .Select(x => SelectAppointmentResponse.FromAppointment(x, INCLUDEOBJECTS))
                .ToList();

            return new PagedResult<SelectAppointmentResponse>(appointmentsResponse, pageNumber, pageSize, totalRecords);
        }
    }
}