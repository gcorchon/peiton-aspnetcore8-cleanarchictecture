using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITareaSubcategoriaRepository))]
public class TareaSubcategoriaRepository : RepositoryBase<TareaSubcategoria>, ITareaSubcategoriaRepository
{
	public TareaSubcategoriaRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
