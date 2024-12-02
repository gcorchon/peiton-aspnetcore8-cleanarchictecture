using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITuteladoSaludPsiquicaRepository))]
public class TuteladoSaludPsiquicaRepository(PeitonDbContext dbContext) : RepositoryBase<TuteladoSaludPsiquica>(dbContext), ITuteladoSaludPsiquicaRepository
{
}
