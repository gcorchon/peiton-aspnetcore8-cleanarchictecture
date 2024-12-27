using Microsoft.EntityFrameworkCore;
using Peiton.Authorization;
using Peiton.Core;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
namespace Peiton.Infrastructure.Repositories;

[Injectable(typeof(IArchivoRepository))]
public class ArchivoRepository(PeitonDbContext dbContext, IIdentityService identityService) : RepositoryBase<Archivo>(dbContext), IArchivoRepository
{
	public async Task<Archivo[]> ObtenerArchivosAsync(int tuteladoId)
	{
		var categorias = await ObtenerCategoriasPermitidasAsync();
		return await DbSet.Include(a => a.CategoriaArchivo).ThenInclude(c => c.CategoriaArchivoPadre)
					.Where(a => a.TuteladoId == tuteladoId && categorias.Contains(a.CategoriaArchivo.CategoriaArchivoPadre!.Id))
					.ToArrayAsync();
	}

	private async Task<IEnumerable<int>> ObtenerCategoriasPermitidasAsync()
	{
		var dict = new Dictionary<int, int>(){
			{ PeitonPermission.GestionIndividualDocumentosInmuebles, 34 },
			{ PeitonPermission.GestionIndividualDocumentosEconomicos, 75 },
			{ PeitonPermission.GestionIndividualDocumentosJuridicos, 35 },
			{ PeitonPermission.GestionIndividualDocumentosRSAT, 112 },
			{ PeitonPermission.GestionIndividualDocumentosSociales, 76 },
			{ PeitonPermission.GestionIndividualDocumentosEmpleadosHogar, 132 },
			{ PeitonPermission.GestionIndividualDocumentosOtros, 37 },
			{ PeitonPermission.GestionIndividualDocumentosCajaFisica, 199 },
			{ PeitonPermission.GestionIndividualDocumentosTributarios, 200 },
			{ PeitonPermission.GestionIndividualDocumentosAutorizaciones, 232 },
			{ PeitonPermission.GestionIndividualDocumentosSalud, 273 },
			{ PeitonPermission.GestionIndividualDocumentosValoracion, 275 },
			{ PeitonPermission.GestionIndividualDocumentosProcedimientosAdicionales, 314 },
			{ PeitonPermission.GestionIndividualDocumentosAcogida, 354 },
			{ PeitonPermission.GestionIndividualDocumentosRendiciones, 379 },
		};

		var lista = new List<int>();

		foreach (var kv in dict)
		{
			if (await identityService.HasPermissionAsync(kv.Key))
			{
				lista.Add(kv.Value);
			}
		}

		return lista;

	}
}
