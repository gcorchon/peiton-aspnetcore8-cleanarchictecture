using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoPrestamoRepository))]
public class TipoPrestamoRepository(PeitonDbContext dbContext) : RepositoryBase<TipoPrestamo>(dbContext), ITipoPrestamoRepository
{
}
