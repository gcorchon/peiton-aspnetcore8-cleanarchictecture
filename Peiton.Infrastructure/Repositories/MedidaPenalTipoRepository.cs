using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IMedidaPenalTipoRepository))]
public class MedidaPenalTipoRepository(PeitonDbContext dbContext) : RepositoryBase<MedidaPenalTipo>(dbContext), IMedidaPenalTipoRepository
{
}
