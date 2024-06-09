using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITipoCentroRepository))]
	public class TipoCentroRepository: RepositoryBase<TipoCentro>, ITipoCentroRepository
	{
		public TipoCentroRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}