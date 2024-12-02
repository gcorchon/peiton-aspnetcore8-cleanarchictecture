using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IConcienciaEnfermedadRepository))]
public class ConcienciaEnfermedadRepository(PeitonDbContext dbContext) : RepositoryBase<ConcienciaEnfermedad>(dbContext), IConcienciaEnfermedadRepository
{
}
