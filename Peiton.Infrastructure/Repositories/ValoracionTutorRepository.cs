using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IValoracionTutorRepository))]
public class ValoracionTutorRepository(PeitonDbContext dbContext) : RepositoryBase<ValoracionTutor>(dbContext), IValoracionTutorRepository
{
}
