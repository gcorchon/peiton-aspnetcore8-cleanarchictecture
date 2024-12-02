using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDatosJuridicosHistoricoRepository))]
public class DatosJuridicosHistoricoRepository(PeitonDbContext dbContext) : RepositoryBase<DatosJuridicosHistorico>(dbContext), IDatosJuridicosHistoricoRepository
{
}
