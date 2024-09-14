using SalonManager.Auth.Core.Entities;

namespace SalonManager.Auth.Core.Interfaces.Repositories
{
    public interface IUserCommandRepository
    {
        Task<User?> InsertAsync(User entity);
        Task<User> UpdateAsync(User entity, Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> SaveChangesAsync();
        Task<int> CountAsync();
    }
}
