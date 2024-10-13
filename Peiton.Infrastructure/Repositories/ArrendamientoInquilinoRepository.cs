using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IArrendamientoInquilinoRepository))]
public class ArrendamientoInquilinoRepository : RepositoryBase<ArrendamientoInquilino>, IArrendamientoInquilinoRepository
{
	public ArrendamientoInquilinoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
