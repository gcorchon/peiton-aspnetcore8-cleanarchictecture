using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IUrgenciaArchivoRepository))]
public class UrgenciaArchivoRepository(PeitonDbContext dbContext) : RepositoryBase<UrgenciaArchivo>(dbContext), IUrgenciaArchivoRepository
{
}
