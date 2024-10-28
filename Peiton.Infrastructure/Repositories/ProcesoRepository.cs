using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Procesos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IProcesoRepository))]
public class ProcesoRepository : RepositoryBase<Proceso>, IProcesoRepository
{
	public ProcesoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<ProcesoListItem[]> ObtenerProcesosAsync()
	{
		return this.DbContext.Database.SqlQuery<ProcesoListItem>(@$"select cr.Pk_CategoriaProceso as CategoriaProcesoId, cr.Descripcion as Categoria, cr.CssClass,
								ci.Pk_CategoriaProceso as SubcategoriaProcesoId, ci.Descripcion as Subcategoria, i.Pk_Proceso as ProcesoId, i.Descripcion, i.ContentType, i.FileName, i.Fecha
							from CategoriaProceso ci inner join Proceso i on i.Fk_CategoriaProceso = Pk_CategoriaProceso
							inner join (
								select Pk_CategoriaProceso, Descripcion, CssClass
								from CategoriaProceso where Fk_CategoriaProceso is null
							) cr on ci.Fk_CategoriaProceso = cr.Pk_CategoriaProceso").ToArrayAsync();
	}
}
