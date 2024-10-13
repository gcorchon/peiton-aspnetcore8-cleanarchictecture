using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IValoracionEntradaExpedienteRepository))]
public class ValoracionEntradaExpedienteRepository : RepositoryBase<ValoracionEntradaExpediente>, IValoracionEntradaExpedienteRepository
{
	public ValoracionEntradaExpedienteRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
