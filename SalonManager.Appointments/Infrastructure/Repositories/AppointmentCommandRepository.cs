using Microsoft.EntityFrameworkCore;
using SalonManager.Appointments.Core.Entities;
using SalonManager.Appointments.Core.Interfaces.Repositories;
using SalonManager.Appointments.Infrastructure.Context;

namespace SalonManager.Appointments.Infrastructure.Repositories
{
    public class AppointmentCommandRepository : IAppointmentCommandRepository
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<Appointment> _dbSet;
        private readonly ILogger<AppointmentCommandRepository> _logger;
        public AppointmentCommandRepository(AppDbContext context, ILogger<AppointmentCommandRepository> logger)
        {
            _context = context;
            _dbSet = context.Set<Appointment>();
            _logger = logger;
        }

        public async Task<Appointment?> InsertAsync(Appointment entity)
        {
            await _dbSet.AddAsync(entity);
            var result = await SaveChangesAsync();
            return (result) ? entity : null;
        }

        public async Task<bool> DeleteAsync(Guid id, Guid tenantId)
        {
            var entity = await GetByIdAsync(id, tenantId);

            if (entity == null) return true;

            entity.IsActived = false;

            var result = await SaveChangesAsync();
            return result ? entity.IsActived : true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _context.DisposeAsync();
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public async Task<Appointment> UpdateAsync(Appointment entity, Guid id)
        {
            var result = await GetByIdAsync(id);

            if (result == null) return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                await _context.DisposeAsync();
                return null;
            }

            return entity;
        }

        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsActived);
        }

        public async Task<Appointment> GetByIdAsync(Guid id, Guid tenantId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.TenantId == tenantId && x.IsActived);
        }

        public async Task<int> CountAsync(Guid tenantId)
        {
            return await _dbSet.Where(x => x.TenantId == tenantId && x.IsActived).CountAsync();
        }
    }
}
