using SalonManager.Auth.Core.Entities;

namespace SalonManager.Auth.Core.Interfaces.Repositories
{
    public interface IUserQueryRepository
    {
        Task<List<User>> GetAllAsync(int pageNumber, int pageSize);
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetUserByIdAndPasswordAsync(Guid id, string password);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}
