using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAdaptacionCentroRepository))]
public class AdaptacionCentroRepository : RepositoryBase<AdaptacionCentro>, IAdaptacionCentroRepository
{
	public AdaptacionCentroRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
