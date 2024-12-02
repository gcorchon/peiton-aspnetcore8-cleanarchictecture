using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IParentescoRepository))]
public class ParentescoRepository(PeitonDbContext dbContext) : RepositoryBase<Parentesco>(dbContext), IParentescoRepository
{
}
