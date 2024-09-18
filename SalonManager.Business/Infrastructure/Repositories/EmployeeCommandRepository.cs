using SalonManager.Business.Core.Entities;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.Infrastructure.Context;

namespace SalonManager.Business.Infrastructure.Repositories
{
    public class EmployeeCommandRepository : CommandRepository<Employee>, IEmployeeCommandRepository
    {
        public EmployeeCommandRepository(AppDbContext context, ILogger<CommandRepository<Employee>> logger)
            : base(context, logger)
        {
        }
    }
}
