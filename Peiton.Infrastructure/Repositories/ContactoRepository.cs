using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IContactoRepository))]
public class ContactoRepository(PeitonDbContext dbContext) : RepositoryBase<Contacto>(dbContext), IContactoRepository
{
}
