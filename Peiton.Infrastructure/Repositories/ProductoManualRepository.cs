using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IProductoManualRepository))]
public class ProductoManualRepository(PeitonDbContext dbContext) : RepositoryBase<ProductoManual>(dbContext), IProductoManualRepository
{
	public Task<ProductoManual[]> ObtenerProductosManualesAsync(int tuteladoId)
	{
		return DbSet.Include(p => p.EntidadFinanciera).Where(t => t.TuteladoId == tuteladoId).AsNoTracking().ToArrayAsync();
	}
}
