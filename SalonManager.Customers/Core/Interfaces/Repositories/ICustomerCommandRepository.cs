using SalonManager.Customers.Core.Entities;

namespace SalonManager.Customers.Core.Interfaces.Repositories
{
    public interface ICustomerCommandRepository
    {
        Task<Customer> InsertAsync(Customer entity);
        Task<Customer> UpdateAsync(Customer entity, Guid tenantId);
        Task<bool> DeleteAsync(Guid id, Guid tenantId);
        Task<bool> SaveChangesAsync();
        Task<Customer> GetByIdAsync(Guid id, Guid tenantId);
        Task<Customer> GetByIdWithoutTenantIdAsync(Guid id);
        Task<int> CountAsync(Guid tenantId);
    }
}
