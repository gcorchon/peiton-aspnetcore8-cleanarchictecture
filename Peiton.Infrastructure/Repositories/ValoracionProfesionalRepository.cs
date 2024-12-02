using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IValoracionProfesionalRepository))]
public class ValoracionProfesionalRepository(PeitonDbContext dbContext) : RepositoryBase<ValoracionProfesional>(dbContext), IValoracionProfesionalRepository
{
}
