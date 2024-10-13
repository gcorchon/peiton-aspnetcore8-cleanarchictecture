using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IControlInventarioRepository))]
public class ControlInventarioRepository : RepositoryBase<ControlInventario>, IControlInventarioRepository
{
	public ControlInventarioRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
