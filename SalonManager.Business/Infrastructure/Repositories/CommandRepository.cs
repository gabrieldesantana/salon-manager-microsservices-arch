using Microsoft.EntityFrameworkCore;
using SalonManager.Business.Core.Entities;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.Infrastructure.Context;

namespace SalonManager.Business.Infrastructure.Repositories
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        private readonly ILogger<CommandRepository<T>> _logger;
        public CommandRepository(AppDbContext context, ILogger<CommandRepository<T>> logger)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _logger = logger;
        }

        public async Task<T?> InsertAsync(T entity)
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

        public async Task<T> UpdateAsync(T entity, Guid tenantId)
        {
            var result = await GetByIdAsync(entity.Id, entity.TenantId);

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

        public async Task<T> GetByIdAsync(Guid id, Guid tenantId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.TenantId == tenantId && x.IsActived);
        }

        public async Task<T> GetByIdWithoutTenantIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsActived);
        }

        public async Task<int> CountAsync(Guid tenantId)
        {
            return await _dbSet.Where(x => x.TenantId == tenantId && x.IsActived).CountAsync(); 
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync(x => x.IsActived);
        }
    }
}
