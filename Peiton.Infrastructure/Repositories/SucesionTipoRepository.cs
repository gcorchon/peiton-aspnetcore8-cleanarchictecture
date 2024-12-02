using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISucesionTipoRepository))]
public class SucesionTipoRepository(PeitonDbContext dbContext) : RepositoryBase<SucesionTipo>(dbContext), ISucesionTipoRepository
{
}
