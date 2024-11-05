using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Core.UseCases.Test;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{

    [HttpGet("")]
    public async Task<IActionResult> ObtenerDocumentoWordAsync(TestHandler handler)
    {
        var data = await handler.HandleAsync();
        return File(data, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
    }

    [HttpGet("text")]
    public async Task<IActionResult> ObtenerTemplateAsync(TestHandler handler)
    {
        var data = await handler.HandleTemplateAsync();
        return Content(data);
    }
}