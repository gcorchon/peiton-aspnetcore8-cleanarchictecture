using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITuteladoSaludFisicaRepository))]
public class TuteladoSaludFisicaRepository(PeitonDbContext dbContext) : RepositoryBase<TuteladoSaludFisica>(dbContext), ITuteladoSaludFisicaRepository
{
}
