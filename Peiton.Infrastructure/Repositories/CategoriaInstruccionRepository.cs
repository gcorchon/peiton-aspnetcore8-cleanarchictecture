using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ICategoriaInstruccionRepository))]
	public class CategoriaInstruccionRepository: RepositoryBase<CategoriaInstruccion>, ICategoriaInstruccionRepository
	{
		public CategoriaInstruccionRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}