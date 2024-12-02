using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IQuejaTipoRepository))]
public class QuejaTipoRepository(PeitonDbContext dbContext) : RepositoryBase<QuejaTipo>(dbContext), IQuejaTipoRepository
{
}
