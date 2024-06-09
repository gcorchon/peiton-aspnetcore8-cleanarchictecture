using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IMedidaPenalNaturalezaRepository))]
	public class MedidaPenalNaturalezaRepository: RepositoryBase<MedidaPenalNaturaleza>, IMedidaPenalNaturalezaRepository
	{
		public MedidaPenalNaturalezaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}