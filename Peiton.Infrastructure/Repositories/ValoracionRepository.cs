using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IValoracionRepository))]
public class ValoracionRepository(PeitonDbContext dbContext) : RepositoryBase<Valoracion>(dbContext), IValoracionRepository
{
}
