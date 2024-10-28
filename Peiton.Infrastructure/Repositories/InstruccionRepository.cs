using Microsoft.EntityFrameworkCore;
using Peiton.Contracts;
using Peiton.Contracts.Instrucciones;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IInstruccionRepository))]
public class InstruccionRepository : RepositoryBase<Instruccion>, IInstruccionRepository
{
	public InstruccionRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<InstruccionListItem[]> ObtenerInstruccionesAsync()
	{
		return this.DbContext.Database.SqlQuery<InstruccionListItem>(@$"select cr.Pk_CategoriaInstruccion as CategoriaInstruccionId, cr.Descripcion as Categoria, cr.CssClass,
								ci.Pk_CategoriaInstruccion as SubcategoriaInstruccionId, ci.Descripcion as Subcategoria, i.Pk_Instruccion as InstruccionId, i.Descripcion, i.ContentType, i.FileName, i.Fecha
							from CategoriaInstruccion ci inner join Instruccion i on i.Fk_CategoriaInstruccion = Pk_CategoriaInstruccion
							inner join (
								select Pk_CategoriaInstruccion, Descripcion, CssClass
								from CategoriaInstruccion where Fk_CategoriaInstruccion is null
							) cr on ci.Fk_CategoriaInstruccion = cr.Pk_CategoriaInstruccion").ToArrayAsync();
	}
}
