using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(INivelSoporteRepository))]
public class NivelSoporteRepository : RepositoryBase<NivelSoporte>, INivelSoporteRepository
{
	public NivelSoporteRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
