using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IValoracionResultadoRepository))]
public class ValoracionResultadoRepository : RepositoryBase<ValoracionResultado>, IValoracionResultadoRepository
{
	public ValoracionResultadoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
