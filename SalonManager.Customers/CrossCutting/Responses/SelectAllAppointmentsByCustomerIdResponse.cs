using SalonManager.Customers.CrossCutting.Dtos;

namespace SalonManager.Customers.CrossCutting.Responses
{
    public class SelectAllAppointmentsByCustomerIdResponse
    {
        public List<AppointmentDto> Appointments { get; set; }

    }
}
