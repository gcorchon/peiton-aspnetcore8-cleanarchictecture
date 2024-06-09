using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IRecordatorioRepository))]
	public class RecordatorioRepository: RepositoryBase<Recordatorio>, IRecordatorioRepository
	{
		public RecordatorioRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}