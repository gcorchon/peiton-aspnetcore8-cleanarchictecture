using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;
[Injectable(typeof(IAbogadoExternoRepository))]
public class AbogadoExternoRepository : RepositoryBase<AbogadoExterno>, IAbogadoExternoRepository
{
	public AbogadoExternoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
