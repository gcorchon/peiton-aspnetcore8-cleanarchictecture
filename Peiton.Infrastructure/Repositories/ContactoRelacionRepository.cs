using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IContactoRelacionRepository))]
	public class ContactoRelacionRepository: RepositoryBase<ContactoRelacion>, IContactoRelacionRepository
	{
		public ContactoRelacionRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}
	}
}