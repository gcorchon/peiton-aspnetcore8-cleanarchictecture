using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IQuejaTipoCierreRepository))]
public class QuejaTipoCierreRepository(PeitonDbContext dbContext) : RepositoryBase<QuejaTipoCierre>(dbContext), IQuejaTipoCierreRepository
{
}
