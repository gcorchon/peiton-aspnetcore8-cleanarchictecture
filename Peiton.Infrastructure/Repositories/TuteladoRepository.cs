using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITuteladoRepository))]
	public class TuteladoRepository: RepositoryBase<Tutelado>, ITuteladoRepository
	{
		public TuteladoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}