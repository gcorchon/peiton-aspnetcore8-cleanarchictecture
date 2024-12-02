using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITextoEstaticoRepository))]
public class TextoEstaticoRepository(PeitonDbContext dbContext) : RepositoryBase<TextoEstatico>(dbContext), ITextoEstaticoRepository
{
}
