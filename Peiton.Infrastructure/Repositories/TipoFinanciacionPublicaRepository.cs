using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoFinanciacionPublicaRepository))]
public class TipoFinanciacionPublicaRepository(PeitonDbContext dbContext) : RepositoryBase<TipoFinanciacionPublica>(dbContext), ITipoFinanciacionPublicaRepository
{
}
