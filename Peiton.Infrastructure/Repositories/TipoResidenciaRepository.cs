using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITipoResidenciaRepository))]
public class TipoResidenciaRepository(PeitonDbContext dbContext) : RepositoryBase<TipoResidencia>(dbContext), ITipoResidenciaRepository
{
}
