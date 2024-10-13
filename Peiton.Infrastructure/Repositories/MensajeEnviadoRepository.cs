using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMensajeEnviadoRepository))]
public class MensajeEnviadoRepository : RepositoryBase<MensajeEnviado>, IMensajeEnviadoRepository
{
	public MensajeEnviadoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
