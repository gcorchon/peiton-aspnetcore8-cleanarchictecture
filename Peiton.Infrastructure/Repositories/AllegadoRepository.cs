using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAllegadoRepository))]
public class AllegadoRepository(PeitonDbContext dbContext) : RepositoryBase<Allegado>(dbContext), IAllegadoRepository
{
}
