using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IDirectorioAMTARepository))]
	public class DirectorioAMTARepository: RepositoryBase<DirectorioAMTA>, IDirectorioAMTARepository
	{
		public DirectorioAMTARepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}