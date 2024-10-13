using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoRelacionConvivencionalRepository))]
public class TipoRelacionConvivencionalRepository : RepositoryBase<TipoRelacionConvivencional>, ITipoRelacionConvivencionalRepository
{
	public TipoRelacionConvivencionalRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
