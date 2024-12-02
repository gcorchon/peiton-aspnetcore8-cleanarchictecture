using Peiton.Core.Repositories;
using Peiton.Core.Entities;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;

[Injectable(typeof(IGestorAdministrativoRepository))]
public class GestorAdministrativoRepository(PeitonDbContext dbContext) : RepositoryBase<GestorAdministrativo>(dbContext), IGestorAdministrativoRepository
{
}
