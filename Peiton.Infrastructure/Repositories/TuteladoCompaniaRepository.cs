using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITuteladoCompaniaRepository))]
public class TuteladoCompaniaRepository(PeitonDbContext dbContext) : RepositoryBase<TuteladoCompania>(dbContext), ITuteladoCompaniaRepository
{
}
