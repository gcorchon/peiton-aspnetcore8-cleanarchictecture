using Peiton.Contracts.Caja;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IIncidenciaRepository))]
public class IncidenciaRepository(PeitonDbContext dbContext) : RepositoryBase<Incidencia>(dbContext), IIncidenciaRepository
{
}
