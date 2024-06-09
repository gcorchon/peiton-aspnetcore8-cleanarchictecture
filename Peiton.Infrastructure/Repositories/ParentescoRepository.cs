using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IParentescoRepository))]
	public class ParentescoRepository: RepositoryBase<Parentesco>, IParentescoRepository
	{
		public ParentescoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}