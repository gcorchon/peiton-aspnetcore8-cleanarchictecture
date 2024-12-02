using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICategoriaConsultaRepository))]
public class CategoriaConsultaRepository(PeitonDbContext dbContext) : RepositoryBase<CategoriaConsulta>(dbContext), ICategoriaConsultaRepository
{
}
