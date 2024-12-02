using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDocumentoGeneradoRepository))]
public class DocumentoGeneradoRepository(PeitonDbContext dbContext) : RepositoryBase<DocumentoGenerado>(dbContext), IDocumentoGeneradoRepository
{
	public Task<DocumentoGenerado[]> ObtenerDocumentosAsync()
	{
		return DbSet.Include(d => d.CategoriaDocumentoGenerado).AsNoTracking().ToArrayAsync();
	}
}
