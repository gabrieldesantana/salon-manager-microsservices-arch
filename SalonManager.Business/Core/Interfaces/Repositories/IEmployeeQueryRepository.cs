using SalonManager.Business.Core.Entities;

namespace SalonManager.Business.Core.Interfaces.Repositories
{
    public interface IEmployeeQueryRepository
    {
        Task<List<Employee>> GetAllAsync(Guid tenantId, int pageNumber, int pageSize);
        Task<Employee> GetByIdAsync(Guid id, Guid tenantId);
        //Task<Employee> GetByIdCleanAsync(Guid id, Guid tenantId);
    }
}
