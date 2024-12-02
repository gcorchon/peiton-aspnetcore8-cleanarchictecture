using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMedidaPenalNaturalezaRepository))]
public class MedidaPenalNaturalezaRepository(PeitonDbContext dbContext) : RepositoryBase<MedidaPenalNaturaleza>(dbContext), IMedidaPenalNaturalezaRepository
{
}
