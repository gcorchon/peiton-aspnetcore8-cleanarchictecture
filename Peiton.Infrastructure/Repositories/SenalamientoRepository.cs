using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISenalamientoRepository))]
public class SenalamientoRepository : RepositoryBase<Senalamiento>, ISenalamientoRepository
{
	public SenalamientoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
