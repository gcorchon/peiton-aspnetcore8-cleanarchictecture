using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEntidadDerivanteRepository))]
public class EntidadDerivanteRepository(PeitonDbContext dbContext) : RepositoryBase<EntidadDerivante>(dbContext), IEntidadDerivanteRepository
{
}
