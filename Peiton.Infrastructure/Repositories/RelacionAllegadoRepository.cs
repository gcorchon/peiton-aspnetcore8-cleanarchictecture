using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRelacionAllegadoRepository))]
public class RelacionAllegadoRepository : RepositoryBase<RelacionAllegado>, IRelacionAllegadoRepository
{
	public RelacionAllegadoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
