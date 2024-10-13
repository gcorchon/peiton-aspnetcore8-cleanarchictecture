using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITextoEstaticoRepository))]
public class TextoEstaticoRepository : RepositoryBase<TextoEstatico>, ITextoEstaticoRepository
{
	public TextoEstaticoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
