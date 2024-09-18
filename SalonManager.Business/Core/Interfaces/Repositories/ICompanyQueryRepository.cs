using SalonManager.Business.Core.Entities;

namespace SalonManager.Business.Core.Interfaces.Repositories
{
    public interface ICompanyQueryRepository
    {
        Task<List<Company>> GetAllAsync(int pageNumber, int pageSize);
        Task<Company> GetByIdAsync(Guid id, Guid tenantId);
    }
}
