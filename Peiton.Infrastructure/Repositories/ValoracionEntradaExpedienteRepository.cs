using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IValoracionEntradaExpedienteRepository))]
public class ValoracionEntradaExpedienteRepository(PeitonDbContext dbContext) : RepositoryBase<ValoracionEntradaExpediente>(dbContext), IValoracionEntradaExpedienteRepository
{
}
