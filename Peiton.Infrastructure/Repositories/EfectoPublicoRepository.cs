using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEfectoPublicoRepository))]
public class EfectoPublicoRepository(PeitonDbContext dbContext) : RepositoryBase<EfectoPublico>(dbContext), IEfectoPublicoRepository
{
}
