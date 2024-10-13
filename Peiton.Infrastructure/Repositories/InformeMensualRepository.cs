using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInformeMensualRepository))]
public class InformeMensualRepository : RepositoryBase<InformeMensual>, IInformeMensualRepository
{
	public InformeMensualRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
