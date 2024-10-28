using Microsoft.EntityFrameworkCore;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;


namespace Peiton.Infrastructure.Repositories;


[Injectable(typeof(IAbogadoRepository))]
public class AbogadoRepository : RepositoryBase<Abogado>, IAbogadoRepository
{
	public AbogadoRepository(PeitonDbContext dbContext) : base(dbContext)
	{

	}

	public Task<Abogado[]> AbogadosParaSenalamientoAsync(string nombre)
	{
		var nombreContains = "%" + nombre + "%";
		return DbSet.FromSql(@$"SELECT Abogado.*
                      FROM Abogado inner join Usuario on Usuario.NombreCompleto = Abogado.Nombre
                      where Usuario.Bloqueado = 0 and Abogado.nombre like {nombreContains} COLLATE Modern_Spanish_ci_ai and Abogado.Senalamientos=1
                      ").OrderBy(a => a.Nombre).Take(10).ToArrayAsync();
	}
}
