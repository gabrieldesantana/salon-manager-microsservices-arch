using SalonManager.Appointments.Core.Entities;

namespace SalonManager.Appointments.Core.Interfaces.Repositories
{
    public interface IAppointmentCommandRepository
    {
        Task<Appointment?> InsertAsync(Appointment entity);
        Task<Appointment> UpdateAsync(Appointment entity, Guid id);
        Task<bool> DeleteAsync(Guid id, Guid tenantId);
        Task<bool> SaveChangesAsync();
        Task<Appointment> GetByIdAsync(Guid id, Guid tenantId);
        Task<int> CountAsync(Guid tenantId);
    }
}
