using Microsoft.EntityFrameworkCore;
using SalonManager.Customers.Core.Entities;
using SalonManager.Customers.Core.Interfaces.Repositories;
using SalonManager.Customers.Infrastructure.Context;

namespace SalonManager.Customers.Infrastructure.Repositories
{
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<Customer> _dbSet;
        private readonly ILogger<CustomerCommandRepository> _logger;
        public CustomerCommandRepository(AppDbContext context, ILogger<CustomerCommandRepository> logger)
        {
            _context = context;
            _dbSet = context.Set<Customer>();
            _logger = logger;
        }

        public async Task<Customer> GetByIdAsync(Guid id, Guid tenantId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.TenantId == tenantId && x.IsActived);
        }

        public async Task<Customer> GetByIdWithoutTenantIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsActived);
        }

        public async Task<Customer> InsertAsync(Customer entity)
        {
            await _dbSet.AddAsync(entity);
            var result = await SaveChangesAsync();
            return (result) ? entity : null;
        }

        public async Task<Customer> UpdateAsync(Customer entity, Guid tenantId)
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

        public async Task<bool> DeleteAsync(Guid id, Guid tenantId)
        {
            var entity = await GetByIdAsync(id, tenantId);
            if (entity == null) return true;

            entity.IsActived = false;

            var result = await SaveChangesAsync();

            return result;
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

        public async Task<int> CountAsync(Guid tenantId)
        {
            return await _dbSet.Where(x => x.TenantId == tenantId && x.IsActived).CountAsync();
        }
    }
}
