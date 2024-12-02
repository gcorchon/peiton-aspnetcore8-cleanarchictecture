using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITuteladoAllegadoRepository))]
public class TuteladoAllegadoRepository(PeitonDbContext dbContext) : RepositoryBase<TuteladoAllegado>(dbContext), ITuteladoAllegadoRepository
{
}
