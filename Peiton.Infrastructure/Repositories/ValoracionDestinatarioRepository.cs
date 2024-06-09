using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IValoracionDestinatarioRepository))]
	public class ValoracionDestinatarioRepository: RepositoryBase<ValoracionDestinatario>, IValoracionDestinatarioRepository
	{
		public ValoracionDestinatarioRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}