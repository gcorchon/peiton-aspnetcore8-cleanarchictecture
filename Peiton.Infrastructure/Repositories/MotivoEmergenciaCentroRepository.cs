using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMotivoEmergenciaCentroRepository))]
public class MotivoEmergenciaCentroRepository : RepositoryBase<MotivoEmergenciaCentro>, IMotivoEmergenciaCentroRepository
{
	public MotivoEmergenciaCentroRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
