using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IJuzgadoRepository))]
public class JuzgadoRepository(PeitonDbContext dbContext) : RepositoryBase<Juzgado>(dbContext), IJuzgadoRepository
{
}
