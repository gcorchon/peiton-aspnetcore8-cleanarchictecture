using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ITareaDepartamentoRepository))]
	public class TareaDepartamentoRepository: RepositoryBase<TareaDepartamento>, ITareaDepartamentoRepository
	{
		public TareaDepartamentoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}