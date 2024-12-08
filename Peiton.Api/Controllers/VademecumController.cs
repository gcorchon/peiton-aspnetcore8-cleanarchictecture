using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using System.ComponentModel.DataAnnotations;
using Peiton.Core.UseCases.Vademecum;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VademecumController() : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> VademecumAsync([FromQuery][Required] DateTime fecha, VademecumHandler handler)
    {
        var data = await handler.HandleAsync(fecha);
        
        return File(data.Data, data.MimeType, data.FileName);
    }
}