using SalonManager.Customers.Core.Entities;

namespace SalonManager.Customers.Core.Interfaces.Repositories
{
    public interface ICustomerQueryRepository
    {
        Task<List<Customer>> GetAllAsync(Guid tenantId, int pageNumber, int pageSize);
        Task<Customer> GetByIdAsync(Guid id, Guid tenantId);
        Task<Customer> GetByIdCleanAsync(Guid id, Guid tenantId);
    }
}
