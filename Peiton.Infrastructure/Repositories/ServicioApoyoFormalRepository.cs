using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IServicioApoyoFormalRepository))]
public class ServicioApoyoFormalRepository : RepositoryBase<ServicioApoyoFormal>, IServicioApoyoFormalRepository
{
	public ServicioApoyoFormalRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
