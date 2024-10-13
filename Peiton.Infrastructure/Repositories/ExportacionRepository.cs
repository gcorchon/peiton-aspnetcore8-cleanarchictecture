using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IExportacionRepository))]
public class ExportacionRepository : RepositoryBase<Exportacion>, IExportacionRepository
{
	public ExportacionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
