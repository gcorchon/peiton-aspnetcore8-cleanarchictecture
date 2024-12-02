using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDondeConvivencionalRepository))]
public class DondeConvivencionalRepository(PeitonDbContext dbContext) : RepositoryBase<DondeConvivencional>(dbContext), IDondeConvivencionalRepository
{
}
