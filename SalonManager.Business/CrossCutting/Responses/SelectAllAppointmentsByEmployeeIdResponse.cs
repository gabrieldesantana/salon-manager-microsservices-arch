using SalonManager.Business.CrossCutting.Dtos;

namespace SalonManager.Business.CrossCutting.Responses
{
    public class SelectAllAppointmentsByEmployeeIdResponse
    {
        public List<AppointmentDto> Appointments { get; set; }
    }
}
