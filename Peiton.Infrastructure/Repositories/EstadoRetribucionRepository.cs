using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEstadoRetribucionRepository))]
public class EstadoRetribucionRepository(PeitonDbContext dbContext) : RepositoryBase<EstadoRetribucion>(dbContext), IEstadoRetribucionRepository
{
}
