using SalonManager.Appointments.Core.Entities;
using SalonManager.Appointments.Features.Appointments.Queries.Select;

namespace SalonManager.Appointments.Features.Appointments.Queries.SelectByCustomerId
{
    public class SelectAllAppointmentsByCustomerIdResponse
    {
        public List<SelectAppointmentResponse> Appointments { get; private set; }
        private const bool INCLUDEOBJECTS = false;

        public SelectAllAppointmentsByCustomerIdResponse(List<Appointment> appointments)
        {
            Appointments = FromAppointments(appointments);
        }

        private List<SelectAppointmentResponse> FromAppointments(List<Appointment> appointments)
        {
            var SelectAppointments = new List<SelectAppointmentResponse>();

            foreach (var appointment in appointments)
            {
                SelectAppointments.Add(SelectAppointmentResponse.FromAppointment(appointment, includeObjects: INCLUDEOBJECTS));
            }

            return SelectAppointments;
        }
    }
}
