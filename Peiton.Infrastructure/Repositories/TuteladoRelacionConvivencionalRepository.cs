using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITuteladoRelacionConvivencionalRepository))]
	public class TuteladoRelacionConvivencionalRepository: RepositoryBase<TuteladoRelacionConvivencional>, ITuteladoRelacionConvivencionalRepository
	{
		public TuteladoRelacionConvivencionalRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}