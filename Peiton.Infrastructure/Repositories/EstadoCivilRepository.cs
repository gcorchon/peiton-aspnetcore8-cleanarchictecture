using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEstadoCivilRepository))]
public class EstadoCivilRepository(PeitonDbContext dbContext) : RepositoryBase<EstadoCivil>(dbContext), IEstadoCivilRepository
{
}
