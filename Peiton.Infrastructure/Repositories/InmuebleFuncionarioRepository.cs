using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInmuebleFuncionarioRepository))]
public class InmuebleFuncionarioRepository(PeitonDbContext dbContext) : RepositoryBase<InmuebleFuncionario>(dbContext), IInmuebleFuncionarioRepository
{
}
