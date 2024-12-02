using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITuteladoRelacionConvivencionalRepository))]
public class TuteladoRelacionConvivencionalRepository(PeitonDbContext dbContext) : RepositoryBase<TuteladoRelacionConvivencional>(dbContext), ITuteladoRelacionConvivencionalRepository
{
}
