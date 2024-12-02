using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IOrigenExpedienteRepository))]
public class OrigenExpedienteRepository(PeitonDbContext dbContext) : RepositoryBase<OrigenExpediente>(dbContext), IOrigenExpedienteRepository
{
}
