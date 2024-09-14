using Microsoft.EntityFrameworkCore;
using SalonManager.Auth.Core.Entities;
using SalonManager.Auth.Core.Interfaces.Repositories;
using SalonManager.Auth.Infrastructure.Context;

namespace SalonManager.Auth.Infrastructure.Repositories
{
    public class UserCommandRepository : IUserCommandRepository
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<User> _dbSet;
        private readonly ILogger<UserCommandRepository> _logger;
        public UserCommandRepository(AppDbContext context, ILogger<UserCommandRepository> logger)
        {
            _context = context;
            _dbSet = context.Set<User>();
            _logger = logger;
        }

        public async Task<User?> InsertAsync(User entity)
        {
            await _dbSet.AddAsync(entity);
            var result = await SaveChangesAsync();
            return (result) ? entity : null;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null) 
                return true;

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

        public async Task<User> UpdateAsync(User entity, Guid id)
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

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsActived);
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync(x => x.IsActived);
        }
    }
}
