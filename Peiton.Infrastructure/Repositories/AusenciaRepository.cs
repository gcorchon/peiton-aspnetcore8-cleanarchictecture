using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAusenciaRepository))]
public class AusenciaRepository : RepositoryBase<Ausencia>, IAusenciaRepository
{
	public AusenciaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
