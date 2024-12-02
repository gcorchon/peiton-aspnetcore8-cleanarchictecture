using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleAvisoCosteRepository))]
public class InmuebleAvisoCosteRepository(PeitonDbContext dbContext) : RepositoryBase<InmuebleAvisoCoste>(dbContext), IInmuebleAvisoCosteRepository
{
}
