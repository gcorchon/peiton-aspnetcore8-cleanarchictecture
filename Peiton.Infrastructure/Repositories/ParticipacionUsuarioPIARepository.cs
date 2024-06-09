using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IParticipacionUsuarioPIARepository))]
	public class ParticipacionUsuarioPIARepository: RepositoryBase<ParticipacionUsuarioPIA>, IParticipacionUsuarioPIARepository
	{
		public ParticipacionUsuarioPIARepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}