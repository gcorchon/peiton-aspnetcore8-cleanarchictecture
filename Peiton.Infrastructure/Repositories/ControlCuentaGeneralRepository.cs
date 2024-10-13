using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IControlCuentaGeneralRepository))]
public class ControlCuentaGeneralRepository : RepositoryBase<ControlCuentaGeneral>, IControlCuentaGeneralRepository
{
	public ControlCuentaGeneralRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
