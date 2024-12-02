using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPrestamoRepository))]
public class PrestamoRepository(PeitonDbContext dbContext) : RepositoryBase<Prestamo>(dbContext), IPrestamoRepository
{
}
