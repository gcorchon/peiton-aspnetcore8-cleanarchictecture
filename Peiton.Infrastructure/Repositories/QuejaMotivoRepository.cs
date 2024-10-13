using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IQuejaMotivoRepository))]
public class QuejaMotivoRepository : RepositoryBase<QuejaMotivo>, IQuejaMotivoRepository
{
	public QuejaMotivoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
