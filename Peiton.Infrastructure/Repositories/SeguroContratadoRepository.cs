using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(ISeguroContratadoRepository))]
public class SeguroContratadoRepository(PeitonDbContext dbContext) : RepositoryBase<SeguroContratado>(dbContext), ISeguroContratadoRepository
{
}
