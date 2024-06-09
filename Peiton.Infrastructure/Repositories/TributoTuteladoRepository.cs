using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITributoTuteladoRepository))]
	public class TributoTuteladoRepository: RepositoryBase<TributoTutelado>, ITributoTuteladoRepository
	{
		public TributoTuteladoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}