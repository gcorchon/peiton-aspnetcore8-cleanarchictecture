﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Usuarios;
using Peiton.Core;
using Peiton.Core.UseCases.Usuarios;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController(IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> UsuariosAsync(UsuariosHandler handler)
    {
        var data = await handler.HandleAsync();
        var vm = mapper.Map<IEnumerable<UsuarioConGrupos>>(data);
        return Ok(vm);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserByIdAsync(int id, GetUserByIdHandler handler)
    {
        var usuario = await handler.HandleAsync(id);
        if (usuario is null) return NotFound();
        return Ok(usuario);
    }

    [HttpGet("usuarios-y-grupos")]
    public async Task<IActionResult> UsuariosGruposAsync([FromQuery] string q, ObtenerUsuariosGruposHandler handler)
    {
        var data = await handler.HandleAsync(q);
        return Ok(data);
    }


}