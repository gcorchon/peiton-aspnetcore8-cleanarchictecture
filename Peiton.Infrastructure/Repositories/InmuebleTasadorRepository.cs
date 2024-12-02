using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleTasadorRepository))]
public class InmuebleTasadorRepository(PeitonDbContext dbContext) : RepositoryBase<InmuebleTasador>(dbContext), IInmuebleTasadorRepository
{
}
