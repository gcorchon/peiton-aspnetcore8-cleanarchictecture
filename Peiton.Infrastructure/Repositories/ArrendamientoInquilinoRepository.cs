using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IArrendamientoInquilinoRepository))]
public class ArrendamientoInquilinoRepository(PeitonDbContext dbContext) : RepositoryBase<ArrendamientoInquilino>(dbContext), IArrendamientoInquilinoRepository
{
}
