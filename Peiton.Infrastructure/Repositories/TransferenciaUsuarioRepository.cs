using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ITransferenciaUsuarioRepository))]
public class TransferenciaUsuarioRepository(PeitonDbContext dbContext) : RepositoryBase<TransferenciaUsuario>(dbContext), ITransferenciaUsuarioRepository
{
}
