using SalonManager.Appointments.Core.Entities;

namespace SalonManager.Appointments.Core.Interfaces.Repositories
{
    public interface IAppointmentQueryRepository
    {
        Task<List<Appointment>> GetAllByCustomerIdAsync(Guid customerId, Guid tenantId);
        Task<List<Appointment>> GetAllByEmployeeIdAsync(Guid employeeId, Guid tenantId);
        Task<Appointment> GetByIdAsync(Guid id, Guid tenantId);
        Task<List<Appointment>> GetAllAsync(Guid tenantId, int pageNumber, int pageSize);
        Task<List<Appointment>> GetAllFinishedByDateAsync(Guid tenantId, DateTime startDate, DateTime endDate);
    }
}
