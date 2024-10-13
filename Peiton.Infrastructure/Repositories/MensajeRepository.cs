using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMensajeRepository))]
public class MensajeRepository : RepositoryBase<Mensaje>, IMensajeRepository
{
	public MensajeRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
