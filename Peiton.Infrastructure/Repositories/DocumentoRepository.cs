using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Documentos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IDocumentoRepository))]
public class DocumentoRepository : RepositoryBase<Documento>, IDocumentoRepository
{
	public DocumentoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<DocumentoListItem[]> ObtenerDocumentosAsync()
	{
		return this.DbContext.Database.SqlQuery<DocumentoListItem>(@$"select cr.Pk_CategoriaDocumento as CategoriaDocumentoId, cr.Descripcion as Categoria, cr.CssClass,
								ci.Pk_CategoriaDocumento as SubcategoriaDocumentoId, ci.Descripcion as Subcategoria, i.Pk_Documento as DocumentoId, i.Descripcion, i.ContentType, i.FileName, i.Fecha
							from CategoriaDocumento ci inner join Documento i on i.Fk_CategoriaDocumento = Pk_CategoriaDocumento
							inner join (
								select Pk_CategoriaDocumento, Descripcion, CssClass
								from CategoriaDocumento where Fk_CategoriaDocumento is null
							) cr on ci.Fk_CategoriaDocumento = cr.Pk_CategoriaDocumento").ToArrayAsync();
	}
}
