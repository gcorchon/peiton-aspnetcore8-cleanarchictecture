using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IVademecumRepository))]
public class VademecumRepository(PeitonDbContext dbContext) : RepositoryBase<Vademecum>(dbContext), IVademecumRepository
{
	
}
