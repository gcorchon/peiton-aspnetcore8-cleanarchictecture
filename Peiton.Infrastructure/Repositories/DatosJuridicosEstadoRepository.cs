using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDatosJuridicosEstadoRepository))]
public class DatosJuridicosEstadoRepository : RepositoryBase<DatosJuridicosEstado>, IDatosJuridicosEstadoRepository
{
	public DatosJuridicosEstadoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
