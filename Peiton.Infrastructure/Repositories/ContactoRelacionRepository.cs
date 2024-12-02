using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IContactoRelacionRepository))]
public class ContactoRelacionRepository(PeitonDbContext dbContext) : RepositoryBase<ContactoRelacion>(dbContext), IContactoRelacionRepository
{
}
