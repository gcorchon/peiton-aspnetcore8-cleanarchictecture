using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITipoCategoriaRepository))]
	public class TipoCategoriaRepository: RepositoryBase<TipoCategoria>, ITipoCategoriaRepository
	{
		public TipoCategoriaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}