using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IArqueoRepository))]
public class ArqueoRepository : RepositoryBase<Arqueo>, IArqueoRepository
{
	public ArqueoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
