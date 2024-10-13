using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUrgenciaCosteRepository))]
public class UrgenciaCosteRepository : RepositoryBase<UrgenciaCoste>, IUrgenciaCosteRepository
{
	public UrgenciaCosteRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
