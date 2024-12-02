using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IProvinciaRepository))]
public class ProvinciaRepository(PeitonDbContext dbContext) : RepositoryBase<Provincia>(dbContext), IProvinciaRepository
{
}
