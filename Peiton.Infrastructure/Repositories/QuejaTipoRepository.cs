using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IQuejaTipoRepository))]
public class QuejaTipoRepository : RepositoryBase<QuejaTipo>, IQuejaTipoRepository
{
	public QuejaTipoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
