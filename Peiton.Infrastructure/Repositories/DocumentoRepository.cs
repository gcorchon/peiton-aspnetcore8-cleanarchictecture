using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Documentos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDocumentoRepository))]
public class DocumentoRepository(PeitonDbContext dbContext) : RepositoryBase<Documento>(dbContext), IDocumentoRepository
{
	public Task<Documento[]> ObtenerDocumentosAsync()
	{
		return DbSet.Include(d => d.CategoriaDocumento)
					.ThenInclude(d => d.CategoriaDocumentoPadre)
					.AsNoTracking().ToArrayAsync();
	}
}
