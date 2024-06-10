using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peiton.Contracts.Capitulo;
using Peiton.Contracts.Partida;
using Peiton.Core.UseCases.Partidas;

namespace Peiton.Api.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class CapitulosController : ControllerBase
{
    [HttpGet()]
    public IAsyncEnumerable<CapituloViewModel> CapitulosYPartidas([FromQuery] CapituloFilter filter, CapitulosYPartidasHandler handler) =>
            handler.HandleAsync(filter);


    [HttpPost()]
    public async Task<IActionResult> CreateCapitulo(CreateCapituloRequest data, CreateCapituloHandler handler)
    {
        try
        {
            await handler.HandleAsync(data);
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException != null && ex.InnerException.Message.Contains("FK_Capitulo_AnoPresupuestario"))
            {
                return ValidationProblem(detail: "No existe el año presupuestario", statusCode: 422);
            }
            else
            {
                return ValidationProblem(detail: ex.GetType().FullName, statusCode: 500);
            }
        }

        return Ok();
    }

    [HttpPost("{id:int}/partidas")]
    public async Task<IActionResult> CreatePartida(int id, [FromBody] CreatePartidaRequest data, CreatePartidaHandler handler)
    {
        try
        {
            await handler.HandleAsync(id, data);
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException != null && ex.InnerException.Message.Contains("IX_Partida"))
            {
                return ValidationProblem(detail: "Número de partida duplicada", statusCode: 422);
            }
            else
            {
                return ValidationProblem(detail: ex.GetType().FullName, statusCode: 500);
            }
        }

        return Ok();
    }

}
