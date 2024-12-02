using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IOtroAsuntoRepository))]
public class OtroAsuntoRepository(PeitonDbContext dbContext) : RepositoryBase<OtroAsunto>(dbContext), IOtroAsuntoRepository
{
}
