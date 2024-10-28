using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Visitas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IRegistroEntradaVisitanteRepository))]
public class RegistroEntradaVisitanteRepository : RepositoryBase<RegistroEntradaVisitante>, IRegistroEntradaVisitanteRepository
{
	public RegistroEntradaVisitanteRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<Visitante[]> ObtenerVisitantesAsync(string query)
	{
		var queryContains = "%" + query + "%";
		return this.DbContext.Database.SqlQuery<Visitante>(@$"select top 10 * from (select top 10 Dni, Nombre, convert(bit,0) as Tutelado 
                                          from RegistroEntradaVisitante where nombre 
                                          like {queryContains} 
                                          union 
                                          select Dni, nombrecompleto as Nombre, convert(bit, 1) as Tutelado
                                          from tutelado where muerto=0 and NombreCompleto like {queryContains}) dv").ToArrayAsync();
	}
}
