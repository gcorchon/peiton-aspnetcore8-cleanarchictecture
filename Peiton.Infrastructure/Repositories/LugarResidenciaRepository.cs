using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ILugarResidenciaRepository))]
public class LugarResidenciaRepository : RepositoryBase<LugarResidencia>, ILugarResidenciaRepository
{
	public LugarResidenciaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
