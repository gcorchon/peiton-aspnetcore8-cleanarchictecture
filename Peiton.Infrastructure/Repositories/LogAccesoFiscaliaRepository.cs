using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(ILogAccesoFiscaliaRepository))]
	public class LogAccesoFiscaliaRepository: RepositoryBase<LogAccesoFiscalia>, ILogAccesoFiscaliaRepository
	{
		public LogAccesoFiscaliaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}