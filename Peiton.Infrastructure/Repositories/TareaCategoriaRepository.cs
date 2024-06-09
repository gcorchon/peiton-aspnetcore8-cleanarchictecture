using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITareaCategoriaRepository))]
	public class TareaCategoriaRepository: RepositoryBase<TareaCategoria>, ITareaCategoriaRepository
	{
		public TareaCategoriaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}