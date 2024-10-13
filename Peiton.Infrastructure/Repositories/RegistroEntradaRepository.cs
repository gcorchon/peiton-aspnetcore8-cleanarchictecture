using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRegistroEntradaRepository))]
public class RegistroEntradaRepository : RepositoryBase<RegistroEntrada>, IRegistroEntradaRepository
{
	public RegistroEntradaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
