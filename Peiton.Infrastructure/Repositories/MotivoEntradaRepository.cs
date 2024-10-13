using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMotivoEntradaRepository))]
public class MotivoEntradaRepository : RepositoryBase<MotivoEntrada>, IMotivoEntradaRepository
{
	public MotivoEntradaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
