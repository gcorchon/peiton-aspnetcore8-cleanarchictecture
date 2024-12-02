using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IEmpresaRepository))]
public class EmpresaRepository(PeitonDbContext dbContext) : RepositoryBase<Empresa>(dbContext), IEmpresaRepository
{
}
