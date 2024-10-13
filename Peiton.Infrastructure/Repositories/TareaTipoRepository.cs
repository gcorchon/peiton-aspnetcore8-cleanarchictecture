using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITareaTipoRepository))]
public class TareaTipoRepository : RepositoryBase<TareaTipo>, ITareaTipoRepository
{
	public TareaTipoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
