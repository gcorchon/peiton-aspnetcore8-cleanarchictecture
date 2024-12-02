using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAmbitoCoberturaServicioRepository))]
public class AmbitoCoberturaServicioRepository(PeitonDbContext dbContext) : RepositoryBase<AmbitoCoberturaServicio>(dbContext), IAmbitoCoberturaServicioRepository
{
}
