using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEstadoSaludRepository))]
public class EstadoSaludRepository(PeitonDbContext dbContext) : RepositoryBase<EstadoSalud>(dbContext), IEstadoSaludRepository
{
}
