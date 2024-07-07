using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories
{


    [Injectable(typeof(IVwCategoriaRepository))]
	public class VwCategoriaRepository: RepositoryBase<VwCategoria>, IVwCategoriaRepository
	{
		public VwCategoriaRepository(PeitonDbContext dbContext) : base(dbContext)
		{

		}

        public Task<List<VwCategoria>> BuscarCategoriasAsync(string text, int total)
        {
            return DbSet.Where(c => c.BreadCrumb.Contains(text)).OrderBy(c => c.BreadCrumb).Take(total).ToListAsync();
        }

        public Task<List<VwCategoria>> ObtenerCategoriasAsync()
        {
            return DbSet.OrderBy(v => v.BreadCrumb).ToListAsync();
        }
    }
}