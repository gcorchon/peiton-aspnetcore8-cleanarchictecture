using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMotivoMuertoUrgenciaRepository))]
public class MotivoMuertoUrgenciaRepository : RepositoryBase<MotivoMuertoUrgencia>, IMotivoMuertoUrgenciaRepository
{
	public MotivoMuertoUrgenciaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
