using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleRepository))]
public class InmuebleRepository(PeitonDbContext dbContext) : RepositoryBase<Inmueble>(dbContext), IInmuebleRepository
{
}
