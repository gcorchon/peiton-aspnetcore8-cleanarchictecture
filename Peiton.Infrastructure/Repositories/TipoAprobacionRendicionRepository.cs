using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoAprobacionRendicionRepository))]
public class TipoAprobacionRendicionRepository : RepositoryBase<TipoAprobacionRendicion>, ITipoAprobacionRendicionRepository
{
	public TipoAprobacionRendicionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
