using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRelacionAMTAContactoRepository))]
public class RelacionAMTAContactoRepository(PeitonDbContext dbContext) : RepositoryBase<RelacionAMTAContacto>(dbContext), IRelacionAMTAContactoRepository
{
}
