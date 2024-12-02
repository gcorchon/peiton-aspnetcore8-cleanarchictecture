using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IValoracionDestinatarioRepository))]
public class ValoracionDestinatarioRepository(PeitonDbContext dbContext) : RepositoryBase<ValoracionDestinatario>(dbContext), IValoracionDestinatarioRepository
{
}
