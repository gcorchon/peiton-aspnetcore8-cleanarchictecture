using Microsoft.AspNetCore.Mvc;
using Peiton.Contracts.Rules;
using Peiton.Core.UseCases.Rules;

namespace Peiton.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesController : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> RulesAsync(ObtenerRulesHandler handler)
        {
            var data = await handler.HandleAsync();
            return Ok(data);
        }

        [HttpPatch("{id:int}/sort")]
        public async Task<IActionResult> ReordernarRulesAsync(int id, [FromBody] ReordenarReglaRequest request, OrdenarRulesHandler handler)
        {
            await handler.HandleAsync(id, request.NewPosition);
            return Accepted();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> BorrarRuleAsync(int id, BorrarRuleHandler handler)
        {
            await handler.HandleAsync(id);
            return Accepted();
        }

    }
}
