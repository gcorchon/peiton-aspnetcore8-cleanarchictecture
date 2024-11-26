using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Common;
using Peiton.Api.Extensions;
using Peiton.Api.Authorization;
using Peiton.Authorization;
using Peiton.Core.UseCases.Accounts;
using Peiton.Core.UseCases.AccountTransactions;
using System.ComponentModel.DataAnnotations;
using Peiton.Core.Utils;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    [HttpGet("extracto")]
    public async Task<IActionResult> ExtractoBancarioAsync([FromQuery][Required] int tuteladoId, [FromQuery][Required] DateTime desde, [FromQuery][Required] DateTime hasta, ExtractoBancarioHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, desde, hasta);

        return Ok(data);
    }

    [HttpGet("extracto/excel")]
    public async Task<IActionResult> ExportExcelExtractoBancarioAsync([FromQuery][Required] int tuteladoId, [FromQuery][Required] DateTime desde, [FromQuery][Required] DateTime hasta, ExportExcelExtractoBancarioHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, desde, hasta);
        return File(data, MimeTypeHelper.Excel, "extracto.xlsx");
    }

    [HttpGet("extracto/word")]
    public async Task<IActionResult> ExportWordExtractoBancarioAsync([FromQuery][Required] int tuteladoId, [FromQuery][Required] DateTime desde, [FromQuery][Required] DateTime hasta, ExportWordExtractoBancarioHandler handler)
    {
        var data = await handler.HandleAsync(tuteladoId, desde, hasta);
        return File(data, MimeTypeHelper.Word, "extracto.docx");
    }

    [HttpPatch("{id:int}/baja")]
    public async Task<IActionResult> DarDeBajaAsync(int id, DarDeBajaHandler handler)
    {
        await handler.HandleAsync(id);
        return Accepted();
    }
}