using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IJuzgadoRepository))]
	public class JuzgadoRepository: RepositoryBase<Juzgado>, IJuzgadoRepository
	{
		public JuzgadoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}