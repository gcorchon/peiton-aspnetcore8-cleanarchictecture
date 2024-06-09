using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IEmergenciaCentroRepository))]
	public class EmergenciaCentroRepository: RepositoryBase<EmergenciaCentro>, IEmergenciaCentroRepository
	{
		public EmergenciaCentroRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}