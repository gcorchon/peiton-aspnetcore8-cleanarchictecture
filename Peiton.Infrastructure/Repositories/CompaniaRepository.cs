using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICompaniaRepository))]
public class CompaniaRepository : RepositoryBase<Compania>, ICompaniaRepository
{
	public CompaniaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
