using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEntidadTutelarRepository))]
public class EntidadTutelarRepository(PeitonDbContext dbContext) : RepositoryBase<EntidadTutelar>(dbContext), IEntidadTutelarRepository
{
}
