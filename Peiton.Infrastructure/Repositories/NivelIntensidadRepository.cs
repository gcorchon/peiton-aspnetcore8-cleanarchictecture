using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(INivelIntensidadRepository))]
public class NivelIntensidadRepository : RepositoryBase<NivelIntensidad>, INivelIntensidadRepository
{
	public NivelIntensidadRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
