using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUrgenciaRepository))]
public class UrgenciaRepository : RepositoryBase<Urgencia>, IUrgenciaRepository
{
	public UrgenciaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
