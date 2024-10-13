using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoCentroDiaRepository))]
public class TipoCentroDiaRepository : RepositoryBase<TipoCentroDia>, ITipoCentroDiaRepository
{
	public TipoCentroDiaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
