using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IMedidaPenalTipoRepository))]
	public class MedidaPenalTipoRepository: RepositoryBase<MedidaPenalTipo>, IMedidaPenalTipoRepository
	{
		public MedidaPenalTipoRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}