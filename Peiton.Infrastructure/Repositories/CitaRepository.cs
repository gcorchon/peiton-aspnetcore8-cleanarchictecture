using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICitaRepository))]
public class CitaRepository(PeitonDbContext dbContext) : RepositoryBase<Cita>(dbContext), ICitaRepository
{
}
