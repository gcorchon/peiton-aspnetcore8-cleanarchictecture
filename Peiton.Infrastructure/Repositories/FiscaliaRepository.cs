using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IFiscaliaRepository))]
public class FiscaliaRepository : RepositoryBase<Fiscalia>, IFiscaliaRepository
{
	public FiscaliaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
