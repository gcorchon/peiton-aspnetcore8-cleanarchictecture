using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IDatosJuridicosHistoricoRepository))]
	public class DatosJuridicosHistoricoRepository: RepositoryBase<DatosJuridicosHistorico>, IDatosJuridicosHistoricoRepository
	{
		public DatosJuridicosHistoricoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}