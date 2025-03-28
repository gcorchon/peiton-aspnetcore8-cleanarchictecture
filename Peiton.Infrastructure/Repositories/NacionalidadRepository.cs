using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(INacionalidadRepository))]
public class NacionalidadRepository(PeitonDbContext dbContext) : RepositoryBase<Nacionalidad>(dbContext), INacionalidadRepository
{
}
