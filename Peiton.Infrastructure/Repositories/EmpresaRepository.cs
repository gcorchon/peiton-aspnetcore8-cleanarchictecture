using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IEmpresaRepository))]
	public class EmpresaRepository: RepositoryBase<Empresa>, IEmpresaRepository
	{
		public EmpresaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}