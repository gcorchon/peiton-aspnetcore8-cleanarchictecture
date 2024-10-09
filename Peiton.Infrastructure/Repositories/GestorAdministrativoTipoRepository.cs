using Peiton.Core.Repositories;
using Peiton.Core.Entities;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{

    [Injectable(typeof(IGestorAdministrativoRepository))]
    public class GestorAdministrativoRepository : RepositoryBase<GestorAdministrativo>, IGestorAdministrativoRepository
    {
        public GestorAdministrativoRepository(PeitonDbContext dbContext) : base(dbContext)
        {

        }
    }
}