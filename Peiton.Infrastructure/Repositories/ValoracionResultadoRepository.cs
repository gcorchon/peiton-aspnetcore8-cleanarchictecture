using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IValoracionResultadoRepository))]
public class ValoracionResultadoRepository(PeitonDbContext dbContext) : RepositoryBase<ValoracionResultado>(dbContext), IValoracionResultadoRepository
{
}
