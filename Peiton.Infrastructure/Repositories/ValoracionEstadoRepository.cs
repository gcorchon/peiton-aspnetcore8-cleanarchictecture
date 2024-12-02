using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IValoracionEstadoRepository))]
public class ValoracionEstadoRepository(PeitonDbContext dbContext) : RepositoryBase<ValoracionEstado>(dbContext), IValoracionEstadoRepository
{
}
