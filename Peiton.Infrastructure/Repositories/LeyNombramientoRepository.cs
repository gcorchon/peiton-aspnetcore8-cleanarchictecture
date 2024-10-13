using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ILeyNombramientoRepository))]
public class LeyNombramientoRepository : RepositoryBase<LeyNombramiento>, ILeyNombramientoRepository
{
	public LeyNombramientoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
