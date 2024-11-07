using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRequerimientoOrigenRepository))]
public class RequerimientoOrigenRepository : RepositoryBase<RequerimientoOrigen>, IRequerimientoOrigenRepository
{
	public RequerimientoOrigenRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
