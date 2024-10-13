using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDuracionLaboralFormativaRepository))]
public class DuracionLaboralFormativaRepository : RepositoryBase<DuracionLaboralFormativa>, IDuracionLaboralFormativaRepository
{
	public DuracionLaboralFormativaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
