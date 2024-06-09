using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IInmuebleFuncionarioRepository))]
	public class InmuebleFuncionarioRepository: RepositoryBase<InmuebleFuncionario>, IInmuebleFuncionarioRepository
	{
		public InmuebleFuncionarioRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}