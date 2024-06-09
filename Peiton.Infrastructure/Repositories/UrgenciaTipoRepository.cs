using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IUrgenciaTipoRepository))]
	public class UrgenciaTipoRepository: RepositoryBase<UrgenciaTipo>, IUrgenciaTipoRepository
	{
		public UrgenciaTipoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}