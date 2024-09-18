using SalonManager.Business.Core.Entities;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.Infrastructure.Context;

namespace SalonManager.Business.Infrastructure.Repositories
{
    public class CompanyCommandRepository : CommandRepository<Company>, ICompanyCommandRepository
    {
        public CompanyCommandRepository(AppDbContext context, ILogger<CommandRepository<Company>> logger)
             : base(context, logger)
        {
        }
    }
}
