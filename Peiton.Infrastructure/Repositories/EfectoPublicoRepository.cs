using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IEfectoPublicoRepository))]
	public class EfectoPublicoRepository: RepositoryBase<EfectoPublico>, IEfectoPublicoRepository
	{
		public EfectoPublicoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}