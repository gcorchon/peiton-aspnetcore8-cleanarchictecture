using Peiton.Contracts.Common;
using Peiton.Contracts.Consultas;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Services;
using Peiton.DependencyInjection;
using System.Data;

namespace Peiton.Core.UseCases.ConsultasAlmacenadas;

[Injectable]
public class EjecutarConsultaAlmacenadaHandler(IConsultaAlmacenadaRepository consultaAlmacenadaRepository, IIdentityService identityService, EjecutarSQLHandler ejecutarSqlHandler)
{
    public async Task<EjecutarSQLResponse> HandleAsync(int id, IEnumerable<ParametroConsulta> parametros)
    {
        var consultaAlmacenada = await consultaAlmacenadaRepository.GetByIdAsync(id);

        if (consultaAlmacenada == null) throw new EntityNotFoundException();

        var usuarioId = identityService.GetUserId();
        if (!await consultaAlmacenadaRepository.PuedeEjecutarConsultaAsync(id, usuarioId))
        {
            throw new UnauthorizedAccessException("No tienes permisos para ejecutar esta consulta");
        }

        return await ejecutarSqlHandler.HandleAsync(new EjecutarSQLRequest() { Query = consultaAlmacenada.Query, Parameters = parametros });
    }

}