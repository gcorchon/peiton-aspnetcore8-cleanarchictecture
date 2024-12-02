using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IControlCuentaGeneralRepository))]
public class ControlCuentaGeneralRepository(PeitonDbContext dbContext) : RepositoryBase<ControlCuentaGeneral>(dbContext), IControlCuentaGeneralRepository
{
}
