using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRegistroEntradaVisitanteRepository))]
public class RegistroEntradaVisitanteRepository : RepositoryBase<RegistroEntradaVisitante>, IRegistroEntradaVisitanteRepository
{
	public RegistroEntradaVisitanteRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
