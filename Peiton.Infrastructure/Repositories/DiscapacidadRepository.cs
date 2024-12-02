using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDiscapacidadRepository))]
public class DiscapacidadRepository(PeitonDbContext dbContext) : RepositoryBase<Discapacidad>(dbContext), IDiscapacidadRepository
{
}
