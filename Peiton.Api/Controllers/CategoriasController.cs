using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Categorias;
using Peiton.Contracts.Common;
using Peiton.Core.Entities;
using Peiton.Core.UseCases.Categorias;
using Peiton.Core.UseCases.Common;

namespace Peiton.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController(IMapper mapper) : ControllerBase
{
    [HttpGet("arbol")]
    public async Task<IActionResult> ArbolCategoriasAsync(ObtenerArbolCategoriasHandler handler)
    {
        var data = await handler.HandleAsync();
        return Ok(data);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> ActualizarCategoriaAsync(int id, [FromBody] ActualizarCategoriaRequest data, ActualizarEntityHandler<Categoria> handler)
    {
        await handler.HandleAsync(id, data);
        return Accepted();
    }

    [HttpPost("{id:int}/categorias")]
    public async Task<IActionResult> CrearSubcategoriaAsync(int id, CrearNuevaCategoriaHandler handler)
    {
        var categoria = await handler.HandleAsync(id);
        var vm = mapper.Map<CategoriaViewModel>(categoria);
        return Ok(vm);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> BorrarCategoriaAsync(int id, BorrarCategoriaHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }

    [HttpGet("")]
    public async Task<IActionResult> BuscarCategoriasAsync([FromQuery] string text, [FromQuery] int total, BuscarCategoriasHandler handler)
    {
        var categorias = await handler.HandleAsync(text, total);
        var vm = mapper.Map<IEnumerable<ListItem>>(categorias);
        return Ok(vm);
    }
}

