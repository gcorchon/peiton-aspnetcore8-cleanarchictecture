using Peiton.Core.Services;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Sucursales;

[Injectable]
public class TraspasosHandler(IDbService dbService)
{
    public async Task HandleAsync(int origenId, int destinoId, string trabajador)
    {
        string[] trabajadores = ["TrabajadorSocial", "Economico", "Abogado", "EducadorSocial", "CoordinadorSocial", "TecnicoIntegracionSocial"];

        if (!trabajadores.Contains(trabajador, StringComparer.CurrentCultureIgnoreCase)) throw new ArgumentException("Trabajador no válido");

        await dbService.ExecuteQueryAsync($"update Tutelado set Fk_{trabajador} = @destinoId where Fk_{trabajador} = @origenId and muerto=0", new { origenId, destinoId });
    }

}
