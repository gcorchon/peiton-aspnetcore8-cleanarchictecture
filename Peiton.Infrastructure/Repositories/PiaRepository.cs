using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IPiaRepository))]
public class PiaRepository(PeitonDbContext dbContext) : RepositoryBase<Pia>(dbContext), IPiaRepository
{
}
