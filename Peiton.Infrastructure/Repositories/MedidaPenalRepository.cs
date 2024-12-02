using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMedidaPenalRepository))]
public class MedidaPenalRepository(PeitonDbContext dbContext) : RepositoryBase<MedidaPenal>(dbContext), IMedidaPenalRepository
{
}
