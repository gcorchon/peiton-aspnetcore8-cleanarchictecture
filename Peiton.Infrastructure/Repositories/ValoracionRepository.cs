using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IValoracionRepository))]
public class ValoracionRepository : RepositoryBase<Valoracion>, IValoracionRepository
{
	public ValoracionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
