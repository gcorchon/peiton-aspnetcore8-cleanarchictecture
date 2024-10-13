using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDiscapacidadTipoRepository))]
public class DiscapacidadTipoRepository : RepositoryBase<DiscapacidadTipo>, IDiscapacidadTipoRepository
{
	public DiscapacidadTipoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
