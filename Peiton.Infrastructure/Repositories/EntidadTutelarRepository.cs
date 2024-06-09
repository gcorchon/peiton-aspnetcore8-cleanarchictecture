using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IEntidadTutelarRepository))]
	public class EntidadTutelarRepository: RepositoryBase<EntidadTutelar>, IEntidadTutelarRepository
	{
		public EntidadTutelarRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}