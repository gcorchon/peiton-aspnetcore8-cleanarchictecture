using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IProductoManualRepository))]
public class ProductoManualRepository : RepositoryBase<ProductoManual>, IProductoManualRepository
{
	public ProductoManualRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<ProductoManual[]> ObtenerProductosManualesAsync(int tuteladoId)
	{
		return DbSet.Include(p => p.EntidadFinanciera).Where(t => t.TuteladoId == tuteladoId).AsNoTracking().ToArrayAsync();
	}
}
