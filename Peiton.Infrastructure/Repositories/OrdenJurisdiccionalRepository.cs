using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IOrdenJurisdiccionalRepository))]
public class OrdenJurisdiccionalRepository(PeitonDbContext dbContext) : RepositoryBase<OrdenJurisdiccional>(dbContext), IOrdenJurisdiccionalRepository
{
}
