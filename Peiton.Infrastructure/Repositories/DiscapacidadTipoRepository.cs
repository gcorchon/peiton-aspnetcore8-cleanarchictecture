using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDiscapacidadTipoRepository))]
public class DiscapacidadTipoRepository(PeitonDbContext dbContext) : RepositoryBase<DiscapacidadTipo>(dbContext), IDiscapacidadTipoRepository
{
}
