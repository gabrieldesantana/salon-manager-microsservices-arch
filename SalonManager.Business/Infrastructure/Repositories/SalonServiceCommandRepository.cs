using SalonManager.Business.Core.Entities;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.Infrastructure.Context;

namespace SalonManager.Business.Infrastructure.Repositories
{
    public class SalonServiceCommandRepository : CommandRepository<SalonService>, ISalonServiceCommandRepository
    {
        public SalonServiceCommandRepository(AppDbContext context, ILogger<CommandRepository<SalonService>> logger) 
            : base(context, logger)
        {
        }
    }
}
