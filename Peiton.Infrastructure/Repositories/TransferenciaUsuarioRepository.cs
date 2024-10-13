using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITransferenciaUsuarioRepository))]
public class TransferenciaUsuarioRepository : RepositoryBase<TransferenciaUsuario>, ITransferenciaUsuarioRepository
{
	public TransferenciaUsuarioRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}
}
