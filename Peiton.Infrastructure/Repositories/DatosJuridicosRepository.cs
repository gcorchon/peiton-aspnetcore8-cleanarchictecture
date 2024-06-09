using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IDatosJuridicosRepository))]
	public class DatosJuridicosRepository: RepositoryBase<DatosJuridicos>, IDatosJuridicosRepository
	{
		public DatosJuridicosRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}