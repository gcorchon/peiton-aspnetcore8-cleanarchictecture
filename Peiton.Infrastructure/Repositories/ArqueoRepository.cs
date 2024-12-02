using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IArqueoRepository))]
public class ArqueoRepository(PeitonDbContext dbContext) : RepositoryBase<Arqueo>(dbContext), IArqueoRepository
{
}
