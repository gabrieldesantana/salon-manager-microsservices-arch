namespace SalonManager.Business.Core.Interfaces.Repositories
{
    public interface ICommandRepository<T> where T : class
    {
        Task<T?> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity, Guid id);
        Task<bool> DeleteAsync(Guid id, Guid tenantId);
        Task<bool> SaveChangesAsync();
        Task<T> GetByIdAsync(Guid id, Guid tenantId);
        Task<T> GetByIdWithoutTenantIdAsync(Guid id);

        Task<int> CountAsync();
        Task<int> CountAsync(Guid tenantId);
    }
}
