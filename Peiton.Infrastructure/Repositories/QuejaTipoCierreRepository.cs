using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IQuejaTipoCierreRepository))]
public class QuejaTipoCierreRepository : RepositoryBase<QuejaTipoCierre>, IQuejaTipoCierreRepository
{
	public QuejaTipoCierreRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
