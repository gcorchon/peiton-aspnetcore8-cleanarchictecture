using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDatosSocialesRepository))]
public class DatosSocialesRepository(PeitonDbContext dbContext) : RepositoryBase<DatosSociales>(dbContext), IDatosSocialesRepository
{
}
