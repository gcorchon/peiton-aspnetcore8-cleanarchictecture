using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IValoracionMedidaCautelarRepository))]
public class ValoracionMedidaCautelarRepository(PeitonDbContext dbContext) : RepositoryBase<ValoracionMedidaCautelar>(dbContext), IValoracionMedidaCautelarRepository
{
}
