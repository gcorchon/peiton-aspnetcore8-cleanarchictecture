using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IVoluntariadoRepository))]
	public class VoluntariadoRepository: RepositoryBase<Voluntariado>, IVoluntariadoRepository
	{
		public VoluntariadoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}