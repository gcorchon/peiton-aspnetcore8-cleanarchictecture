using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITuteladoDiagnosticoRepository))]
public class TuteladoDiagnosticoRepository(PeitonDbContext dbContext) : RepositoryBase<TuteladoDiagnostico>(dbContext), ITuteladoDiagnosticoRepository
{
}
