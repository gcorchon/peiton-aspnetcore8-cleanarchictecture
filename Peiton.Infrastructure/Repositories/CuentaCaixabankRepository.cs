using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ICuentaCaixabankRepository))]
public class CuentaCaixabankRepository(PeitonDbContext dbContext) : RepositoryBase<CuentaCaixabank>(dbContext), ICuentaCaixabankRepository
{
}
