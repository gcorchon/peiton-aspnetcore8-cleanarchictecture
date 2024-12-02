using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IValoracionMedidaPropuestaRepository))]
public class ValoracionMedidaPropuestaRepository(PeitonDbContext dbContext) : RepositoryBase<ValoracionMedidaPropuesta>(dbContext), IValoracionMedidaPropuestaRepository
{
}
