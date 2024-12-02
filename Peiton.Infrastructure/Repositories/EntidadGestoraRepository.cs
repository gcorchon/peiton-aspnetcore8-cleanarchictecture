using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEntidadGestoraRepository))]
public class EntidadGestoraRepository(PeitonDbContext dbContext) : RepositoryBase<EntidadGestora>(dbContext), IEntidadGestoraRepository
{
}
