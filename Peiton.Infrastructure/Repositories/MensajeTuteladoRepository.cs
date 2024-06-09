using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IMensajeTuteladoRepository))]
	public class MensajeTuteladoRepository: RepositoryBase<MensajeTutelado>, IMensajeTuteladoRepository
	{
		public MensajeTuteladoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}