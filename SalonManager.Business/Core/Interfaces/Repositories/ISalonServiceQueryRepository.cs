using SalonManager.Business.Core.Entities;

namespace SalonManager.Business.Core.Interfaces.Repositories
{
    public interface ISalonServiceQueryRepository
    {
        Task<List<SalonService>> GetAllAsync(Guid tenantId, int pageNumber, int pageSize);
        Task<SalonService> GetByIdAsync(Guid id, Guid tenantId);
    }
}
