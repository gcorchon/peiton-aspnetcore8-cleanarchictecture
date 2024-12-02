using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICategoriaAgendaRepository))]
public class CategoriaAgendaRepository(PeitonDbContext dbContext) : RepositoryBase<CategoriaAgenda>(dbContext), ICategoriaAgendaRepository
{
}
