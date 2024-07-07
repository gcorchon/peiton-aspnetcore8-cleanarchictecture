using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ConsultasAlmacenadas;

[Injectable]
public class ObtenerParametrosConsultaHandler(IConsultaAlmacenadaRepository consultaAlmacenadaRepository, IIdentityService identityService, ObtenerParametrosSQLHandler obtenerParametrosSQLHandler)
{
    public async Task<IEnumerable<string>> HandleAsync(int id)
    {
        var consultaAlmacenada = await consultaAlmacenadaRepository.GetByIdAsync(id);

        if (consultaAlmacenada == null) throw new EntityNotFoundException();

        var usuarioId = identityService.GetUserId();
        if (!await consultaAlmacenadaRepository.PuedeEjecutarConsultaAsync(id, usuarioId))
        {
            throw new UnauthorizedAccessException("No tienes permisos para ejecutar esta consulta");
        }

        return await obtenerParametrosSQLHandler.HandleAsync(consultaAlmacenada.Query);
    }

}