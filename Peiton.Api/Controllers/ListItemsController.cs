using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Peiton.ModelBinders;
using Peiton.Core.UseCases.ListItems;

namespace Peiton.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListItemsController : ControllerBase
{
    [HttpGet("{tableName}")]
    public async Task<IActionResult> ListItemsAsync(string tableName, ListItemsHandler handler)
    {
        var data = await handler.HandleAsync(tableName);
        return Ok(data);
    }

    [HttpGet()]
    public async Task<IActionResult> MultipleListItemsAsync([FromQuery][ModelBinder(BinderType = typeof(StringToStringArrayModelBinder))] string[] tableNames, MultipleListItemsHandler handler)
    {
        var data = await handler.HandleAsync(tableNames);

        return Ok(data);
    }
}